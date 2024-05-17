// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Streams;
using System.Text;

namespace FluentAssertions.Expectations.Specs;

public class StreamExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_StreamAssertions()
    {
        var str = "this is some text";
        var buf = Encoding.UTF8.GetBytes(str);
        using var streamValue = new MemoryStream(buf);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(streamValue).To();

        // Assert
        Expect(assertions).To().BeOfType<StreamAssertions>();
        assertions.BeReadable();

        // Verify API equivalency
        var shouldResult = streamValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_BufferedStreamAssertions()
    {
        var genStream = new GeneratorStream(8192);

        BufferedStream bstreamValue = new(genStream, 2048);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(bstreamValue).To();

        // Assert
        Expect(assertions).To().BeOfType<BufferedStreamAssertions>();
        assertions.BeReadable();
        assertions.NotBeSeekable();
        assertions.NotBeWritable();
        assertions.HaveBufferSize(2048);

        // Verify API equivalency
        var shouldResult = bstreamValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    private class GeneratorStream(int maxLength) : Stream
    {
        private int _position = 0;

        private readonly Random r = new();

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => maxLength;
        public override long Position
        {
            get => _position;
            set => throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_position >= maxLength) { return 0; }

            int readCount = Math.Min(count, r.Next(100, 1000));
            if (_position + readCount > maxLength) {
                readCount = maxLength - _position;
            }
            _position += readCount;

            var writeTo = buffer.AsSpan().Slice(offset, readCount);
            r.NextBytes(writeTo);
            return readCount;
        }

        public override void Flush() => throw new NotImplementedException();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();
        public override void SetLength(long value) => throw new NotImplementedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
    }
}

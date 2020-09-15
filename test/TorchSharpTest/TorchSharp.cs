// Copyright (c) Microsoft Corporation and contributors.  All Rights Reserved.  See License.txt in the project root for license information.
using System;
using System.Runtime.InteropServices;
using TorchSharp;
using TorchSharp.Tensor;
using Xunit;

#nullable enable

namespace TorchSharp
{
    public class TestTorch
    {
        [Fact]
        public void TestDeviceCount()
        {
            //var shape = new long[] { 2, 2 };

            var isCudaAvailable = Torch.IsCudaAvailable();
            var isCudnnAvailable = Torch.IsCudnnAvailable();
            var deviceCount = Torch.CudaDeviceCount();
            if (isCudaAvailable) {
                Assert.True(deviceCount > 0);
                Assert.True(isCudnnAvailable);
            } else {
                Assert.Equal(0, deviceCount);
                Assert.False(isCudnnAvailable);
            }

            //TorchTensor t = FloatTensor.Ones(shape);
            //Assert.Equal(shape, t.Shape);
            //Assert.Equal(1.0f, t[0, 0].DataItem<float>());
            //Assert.Equal(1.0f, t[1, 1].DataItem<float>());
        }

        [Fact]
        public void TestMemoryUsage()
        {
            int n = 1000;
            for (int i = 0; i < n; i++) {
                Console.WriteLine("Loop iteration %d", i);

                // This will fail:
                // var x = FloatTensor.Empty(new long[] { 64000, 1000 }, deviceType: DeviceType.CPU);

                // This will succeed:
                using (var x = FloatTensor.Empty(new long[] { 64000, 1000 }, deviceType: DeviceType.CPU)) { }

            }
            Console.WriteLine("Hello World!");
        }

    }
}

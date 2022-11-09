using System.Diagnostics.CodeAnalysis;

namespace WorkerService.Archetype.Test
{
    [ExcludeFromCodeCoverage]
    public class WorkerTest : BaseTest
    {
        [Fact]
        public async Task ExecuteAsync_WhenRunWithCanceledToken_ShouldFinishWithoutErrors()
        {
            //Arrange
            var cancellationToken = new CancellationToken(true);
            var worker = new Worker(_logger, _customService);

            //Act
            await worker.StartAsync(cancellationToken);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public void ExecuteAsync_WhenRunWithNotCanceledToken_ShouldFinishWithoutErrors()
        {
            //Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            var worker = new Worker(_logger, _customService);
            Task[] tasks = new Task[2];

            //Act
            tasks[0] = Task.Factory.StartNew(async () =>
            {
                await Task.Delay(1000);
                cancellationTokenSource.Cancel();
            });
            tasks[1] = worker.StartAsync(cancellationTokenSource.Token);

            Task.WaitAll(tasks);

            //Assert
            Assert.True(true);
        }
    }
}
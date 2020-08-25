using System;
using System.Threading;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public enum ProcessingResult { Sucess, Fail, Cancel }
    public class StaticFunctions
    {
        public static async void ProcessBooking<T>(T booking, Action<T, ProcessingResult> callback, CancellationTokenSource token)
        {
            try
            {
                await Task.Run(async () => await Task.Delay(new TimeSpan(0, 0, 3), token.Token));
            }
            catch (OperationCanceledException)
            {
                callback(booking, ProcessingResult.Cancel);
                return;
            }

            ProcessingResult result = new Random().Next(0, 2) == 0 ? ProcessingResult.Sucess : ProcessingResult.Fail;
            callback(booking, result);
        }
    }
}

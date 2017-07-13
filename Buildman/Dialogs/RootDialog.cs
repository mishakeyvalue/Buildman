using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Buildman.Infrastructure.ServiceLocator;
using Buildman.Jenkins.Managers;

namespace Buildman.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private IJenkinsManager _jenkinsManager;

        public Task StartAsync(IDialogContext context)
        {
            _jenkinsManager = ServiceLocator.GetService<IJenkinsManager>();
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

           

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }

        private Task resume(IDialogContext context, IAwaitable<object> result)
        {
            throw new NotImplementedException();
        }
    }
}
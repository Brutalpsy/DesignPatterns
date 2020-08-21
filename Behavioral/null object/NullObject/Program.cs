using NullObject.Entities;
using NullObject.Services;
using NullObject.View;
using System;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            LearnerService learnerService = new LearnerService();
            ILearner learner = learnerService.GetCurrentLearner();

            LearnerView view = new LearnerView(learner);
            view.RenderView();
        }
    }
}

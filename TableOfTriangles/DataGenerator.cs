using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using BHHCExercise.Models;
using System.Drawing;

namespace BHHCExercise
{
    public enum TableRow { A = 0, B, C }

    public class DataGenerator
    {
        public static readonly string[] Reasons = { "Culture", "Growth", "Impact", "Edge", "Spirit", "Balance"};
        public const int HalfColumnQuantity = 3;
        public const int PixelStep = 10;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TabularReasonContext>();
            if (context.TabularReasons.Any())
                return;

            var rowNames = Enum.GetNames(typeof(TableRow));
            var random = new Random();

            int runningX = 0, runningY = 0, runningCount = 0;
            foreach (var r in rowNames)
            {
                for (int i = 0; i < HalfColumnQuantity; i++)
                {
                    var v11_21 = new Point(runningX, runningY);
                    var v12 = new Point(runningX, runningY + PixelStep);
                    var v13_23 = new Point(runningX + PixelStep, runningY + PixelStep);
                    var v22 = new Point(runningX + PixelStep, runningY);

                    context.TabularReasons.Add(new TabularReason(Reasons[random.Next(Reasons.Count())], v11_21, v12, v13_23, r, ++runningCount));
                    context.TabularReasons.Add(new TabularReason(Reasons[random.Next(Reasons.Count())], v11_21, v22, v13_23, r, ++runningCount));
                    runningX += PixelStep;
                }

                runningX = 0;
                runningY += PixelStep;
                runningCount = 0;
            }
            context.SaveChanges();
        }
    }
}

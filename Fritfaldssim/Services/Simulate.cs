﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fritfaldssim.Services
{
   public class Simulate
   {
      public ObservableCollection<double> time { get;  }
      public ObservableCollection<double> position { get; }
      public ObservableCollection<double> speed { get; }

      public Simulate()
      {
         time = new ObservableCollection<double>();
         position = new ObservableCollection<double>();
         speed = new ObservableCollection<double>();
         RunSimulation(); 
      }

      public void RunSimulation()
      {
         time.Clear(); 
         position.Clear();
         speed.Clear();

         double v2 = 0;
         double v1 = 0;
         double t = 0;
         double DeltaT = 0.001;
         double s2 = 0;
         double s1 = 0;

         double g = 9.82; 

         var Weight = 0.9;
         var formfaktor = 1.0;
         var Density = 1.3;
         var TAreal = 0.8;
         var Time = 5;

         time.Add(t);
         position.Add(s2); 
         speed.Add(v2);

         while (t < Time && Density > 0)
         {
            v2 = ((Weight * g - 0.5 * formfaktor * Math.Pow(v1, 2) * Density * TAreal) / Weight) * DeltaT + v1;
            v1 = v2;
            t = t + DeltaT;
            s2 = v1 * DeltaT + s1;
            s1 = s2;

            time.Add(t);
            position.Add(s2);
            speed.Add(v2);
         }

      }
   }
}

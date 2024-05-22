using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Exercise1.GUI
{
    /// <summary>
    /// This static class provides collections of objects that are provided in lieu of a
    /// relational database. The 'Initialize' method is invoked to fill the collections with
    /// example data.
    /// </summary>
    public static class DataContext
    {
        /// <summary>
        /// The collection of all Run objects in the data context (equivalent to all of the data
        /// from one table in a database).
        /// </summary>
        public static ObservableCollection<Run> Runs { get; set; }
        /// <summary>
        /// The collection of all Inflow objects in the data context (equivalent to all of the data
        /// from one table in a database).
        /// </summary>
        public static ObservableCollection<Inflow> Inflows { get; set; }
        /// <summary>
        /// The collection of all GageReading objects in the data context (equivalent to all of the data
        /// from one table in a database).
        /// </summary>
        public static ObservableCollection<GageReading> GageReadings { get; set; }
        /// <summary>
        /// The collection of all associtions between Run objects and Inflow objects in the data context
        /// (equivalent to all of the data from one *join* table in a database). This stores the
        /// many-to-many relationship between Runs and Inflows.
        /// </summary>
        public static ObservableCollection<RunInflowAssociation> RunInflowAssociations { get; set; }

        /// <summary>
        /// This method fills the collections of the DataContext class with example data
        /// that is suitable for the exercise.
        /// </summary>
        public static void Initialize()
        {
            // Create an artificial collection of Run objects
            Runs = new ObservableCollection<Run>
            {
                new Run(Guid.NewGuid(), "Run 01", "The core", true),
                new Run(Guid.NewGuid(), "Run 02", "trio of", true),
                new Run(Guid.NewGuid(), "Run 03", "Lennon, McCartney", false),
                new Run(Guid.NewGuid(), "Run 04", "and Harrison", false),
                new Run(Guid.NewGuid(), "Run 05", "together since", true),
                new Run(Guid.NewGuid(), "Run 06", "1958, went", false),
                new Run(Guid.NewGuid(), "Run 07", "through a", true),
                new Run(Guid.NewGuid(), "Run 08", "succession of", false),
                new Run(Guid.NewGuid(), "Run 09", "drummers, including", true),
                new Run(Guid.NewGuid(), "Run 10", "Pete Best,", true),
                new Run(Guid.NewGuid(), "Run 11", "before inviting", true),
                new Run(Guid.NewGuid(), "Run 12", "Starr to join them in 1962", false)
            };
            // Create an artificial collection of Inflow objects
            Inflows = new ObservableCollection<Inflow>
            {
                new Inflow(Guid.NewGuid(), 100, "Allan Williams", 1000, 5000),
                new Inflow(Guid.NewGuid(), 110, "the Beatles'", 1100, 5000),
                new Inflow(Guid.NewGuid(), 120, "unofficial manager", 1200, 5000),
                new Inflow(Guid.NewGuid(), 130, "arranged a", 1000, 5000),
                new Inflow(Guid.NewGuid(), 140, "residency for", 1000, 5000),
                new Inflow(Guid.NewGuid(), 150, "them in", 2000, 6000),
                new Inflow(Guid.NewGuid(), 160, "Hamburg. They", 2200, 6000),
                new Inflow(Guid.NewGuid(), 170, "auditioned and", 4000, 6000),
                new Inflow(Guid.NewGuid(), 180, "hired drummer", 5000, 6000),
                new Inflow(Guid.NewGuid(), 190, "Pete Best", 6000, 8000),
                new Inflow(Guid.NewGuid(), 200, "in mid-August", 1500, 8000),
                new Inflow(Guid.NewGuid(), 210, "1960. The", 2000, 8000),
                new Inflow(Guid.NewGuid(), 220, "band, now", 4000, 8000),
                new Inflow(Guid.NewGuid(), 230, "a five-piece,", 4000, 8000),
                new Inflow(Guid.NewGuid(), 240, "departed Liverpool", 4000, 8000),
                new Inflow(Guid.NewGuid(), 250, "for Hamburg", 4000, 8000),
                new Inflow(Guid.NewGuid(), 260, "four days", 1000, 8000),
                new Inflow(Guid.NewGuid(), 270, "later, contracted", 1000, 8000),
                new Inflow(Guid.NewGuid(), 280, "to club", 1000, 8000),
                new Inflow(Guid.NewGuid(), 290, "owner Bruno", 1000, 7000),
                new Inflow(Guid.NewGuid(), 300, "Koschmider for", 1000, 7000),
                new Inflow(Guid.NewGuid(), 310, "what would", 1000, 7000),
                new Inflow(Guid.NewGuid(), 320, "be a", 1000, 7000),
                new Inflow(Guid.NewGuid(), 330, "3+1⁄2-month", 1000, 7000),
                new Inflow(Guid.NewGuid(), 340, "residency.", 1400, 1000),
                new Inflow(Guid.NewGuid(), 350, "Beatles historian", 1400, 1000),
                new Inflow(Guid.NewGuid(), 360, "Mark Lewisohn", 1400, 1000),
                new Inflow(Guid.NewGuid(), 370, "writes: They", 1000, 1000),
                new Inflow(Guid.NewGuid(), 380, "pulled into", 2900, 1000),
                new Inflow(Guid.NewGuid(), 390, "Hamburg at", 2900, 7000),
                new Inflow(Guid.NewGuid(), 400, "dusk on", 2900, 9000),
                new Inflow(Guid.NewGuid(), 410, "17 August", 1000, 9000)
            };
            // Create arrays so that we can get easy index values
            var runArray = Runs.ToArray();
            var inflowArray = Inflows.ToArray();

            // Create an artificial collection of GageReading objects.
            // Because the relationship of Inflow to GageReading is one-to-many, each GageReading
            // is assigned to one Inflow.
            GageReadings = new ObservableCollection<GageReading>
            {
                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[00].GUID),
                new GageReading(Guid.NewGuid(), 3100, GetRandomDate(), inflowArray[00].GUID),
                new GageReading(Guid.NewGuid(), 4000, GetRandomDate(), inflowArray[00].GUID),

                new GageReading(Guid.NewGuid(), 5000, GetRandomDate(), inflowArray[01].GUID),
                new GageReading(Guid.NewGuid(), 6000, GetRandomDate(), inflowArray[01].GUID),

                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[03].GUID),
                new GageReading(Guid.NewGuid(), 2000, GetRandomDate(), inflowArray[03].GUID),
                new GageReading(Guid.NewGuid(), 2000, GetRandomDate(), inflowArray[03].GUID),
                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[03].GUID),

                new GageReading(Guid.NewGuid(), 3300, GetRandomDate(), inflowArray[04].GUID),
                new GageReading(Guid.NewGuid(), 3400, GetRandomDate(), inflowArray[04].GUID),

                new GageReading(Guid.NewGuid(), 3500, GetRandomDate(), inflowArray[05].GUID),

                new GageReading(Guid.NewGuid(), 8000, GetRandomDate(), inflowArray[07].GUID),

                new GageReading(Guid.NewGuid(), 8000, GetRandomDate(), inflowArray[08].GUID),

                new GageReading(Guid.NewGuid(), 3200, GetRandomDate(), inflowArray[09].GUID),

                new GageReading(Guid.NewGuid(), 3200, GetRandomDate(), inflowArray[10].GUID),
                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[10].GUID),
                new GageReading(Guid.NewGuid(), 1000, GetRandomDate(), inflowArray[10].GUID),
                new GageReading(Guid.NewGuid(), 1000, GetRandomDate(), inflowArray[10].GUID),
                new GageReading(Guid.NewGuid(), 1000, GetRandomDate(), inflowArray[10].GUID),

                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[11].GUID),
                new GageReading(Guid.NewGuid(), 3800, GetRandomDate(), inflowArray[11].GUID),
                new GageReading(Guid.NewGuid(), 3800, GetRandomDate(), inflowArray[11].GUID),
                new GageReading(Guid.NewGuid(), 3800, GetRandomDate(), inflowArray[11].GUID),
                new GageReading(Guid.NewGuid(), 3800, GetRandomDate(), inflowArray[11].GUID),

                new GageReading(Guid.NewGuid(), 4000, GetRandomDate(), inflowArray[14].GUID),

                new GageReading(Guid.NewGuid(), 2000, GetRandomDate(), inflowArray[15].GUID),

                new GageReading(Guid.NewGuid(), 1000, GetRandomDate(), inflowArray[18].GUID),

                new GageReading(Guid.NewGuid(), 1000, GetRandomDate(), inflowArray[19].GUID),

                new GageReading(Guid.NewGuid(), 2000, GetRandomDate(), inflowArray[20].GUID),

                new GageReading(Guid.NewGuid(), 4000, GetRandomDate(), inflowArray[21].GUID),
                new GageReading(Guid.NewGuid(), 5000, GetRandomDate(), inflowArray[21].GUID),
                new GageReading(Guid.NewGuid(), 8000, GetRandomDate(), inflowArray[21].GUID),
                new GageReading(Guid.NewGuid(), 8800, GetRandomDate(), inflowArray[21].GUID),
                new GageReading(Guid.NewGuid(), 3800, GetRandomDate(), inflowArray[21].GUID),

                new GageReading(Guid.NewGuid(), 2100, GetRandomDate(), inflowArray[23].GUID),
                new GageReading(Guid.NewGuid(), 2500, GetRandomDate(), inflowArray[23].GUID),
                new GageReading(Guid.NewGuid(), 3300, GetRandomDate(), inflowArray[23].GUID),
                new GageReading(Guid.NewGuid(), 4500, GetRandomDate(), inflowArray[23].GUID),

                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[24].GUID),
                new GageReading(Guid.NewGuid(), 3500, GetRandomDate(), inflowArray[24].GUID),

                new GageReading(Guid.NewGuid(), 3600, GetRandomDate(), inflowArray[25].GUID),

                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[27].GUID),

                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[28].GUID),

                new GageReading(Guid.NewGuid(), 3000, GetRandomDate(), inflowArray[29].GUID)
            };

            // Initialize the many-to-many relationships between Runs and Inflows
            RunInflowAssociations = new ObservableCollection<RunInflowAssociation>();
            // The artificial data are given relationships. The point of the loop counter variables
            // is just to ensure that there are a variable number associations for different objects.
            inflowArray = Inflows.Concat(Inflows).Concat(Inflows).Concat(Inflows).Concat(Inflows).ToArray();
            int i0 = 5, i1 = 6;
            foreach (var run in Runs)
            {
                for (int i = i0; i < i0 + i1; i += 3)
                {
                    RunInflowAssociations.Add(new RunInflowAssociation(run.GUID, inflowArray[i].GUID));
                }
                i0 += 2;
                i1 += 3;
                if (i1 > 21) i1 = 0;
            }
        }
        private static Random _randomizer = new Random();
        /// <summary>
        /// This method is a helper to the 'Initialize' method
        /// </summary>
        private static DateTime GetRandomDate()
        {
            return new DateTime(2015, 1, 1).AddDays(_randomizer.Next(0, 450));
        }
    }
}

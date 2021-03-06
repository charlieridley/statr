using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Statr.Storage
{
    public class DataPointCollection : IEnumerable<DataPoint>
    {
        private readonly IEnumerable<DataPoint> dataPoints;

        public DataPointCollection(IEnumerable<DataPoint> dataPoints)
        {
            this.dataPoints = dataPoints;
        }

        public IEnumerator<DataPoint> GetEnumerator()
        {
            return dataPoints.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SliceData ToSliceData()
        {
            var startTime = this.dataPoints.First().TimeStamp;
            var dataPoints = this.dataPoints.Select(d => d.Value.Value).ToArray();

            return new SliceData(startTime, dataPoints);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace URLWatch
{
    class AccessUri
    {
        public void Get(Options o)
        {
            for (; ; )
            {
                // todo: Change this over for background thread 
                if ( !o.Paused)
                {
                    Uri myuri = new Uri(o.Uri);


                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myuri);
                    request.Timeout = 15000;
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    request.ReadWriteTimeout = request.Timeout;
                    try
                    {
                        using (WebResponse response = request.GetResponse())
                        {
                            sw.Stop();
                        }

                        //Stream receiveStream = response.GetResponseStream();
                        //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                        //string textresponse = readStream.ReadToEnd();
                        UpdateResponseTimeList(o, sw);
                        CalculateNewAverage(o, sw);
                        o.cntAccess++;
                        Debug.WriteLine($"attempt {o.cntAccess} response time {sw.ElapsedMilliseconds}");
                    }
                    catch (Exception ex)
                    {
                        sw.Stop();
                        Debug.Write(ex.ToString());
                        o.cntFailures++;
                        UpdateFailureTimeList(o, sw);
                    }

                }
                System.Threading.Thread.Sleep(o.msReAccess);
            }
        }

        private void UpdateFailureTimeList(Options o, Stopwatch sw)
        {
            o.AccessFailures.Add(new AccessResponse { msResponseTime = sw.ElapsedMilliseconds, Accessed = DateTime.Now });
            if (o.AccessFailures.Count > o.MaxAccessResponse)
            {
                o.AccessFailures.RemoveRange(0, 10);
            }
        }

        private void UpdateResponseTimeList(Options o, Stopwatch sw)
        {
            o.AccessResponses.Add(new AccessResponse { msResponseTime = sw.ElapsedMilliseconds, Accessed = DateTime.Now });
            if (o.AccessResponses.Count > o.MaxAccessResponse)
            {
                o.AccessResponses.RemoveRange(0, 10);
            }
        }

        private void CalculateNewAverage(Options o, Stopwatch sw)
        {
            if (o.msAvgResponseTime == 0)
            {
                o.msAvgResponseTime = sw.ElapsedMilliseconds;
            }
            else
            {
                o.msAvgResponseTime = ((o.msAvgResponseTime * o.cntAccess) + sw.ElapsedMilliseconds) / o.cntAccess;
            }
        }
    }
}

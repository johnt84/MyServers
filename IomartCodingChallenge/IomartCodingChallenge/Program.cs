using IomartCodingChallenge.CodingChallengeServiceReference;
using System;
using System.Linq;

namespace IomartCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiClient = new MyServersApiClient();

            var authInfo = new AuthInfo()
            {
                Username = "C019848@api.rapidswitch.com",
                Password = "Kh:a6,mgiwem^zrotiwyzfaPz",
            };

            //server details actions
            string testServiceID = "TEST-00001";

            //var testServerDetails = apiClient.GetServerDetails(authInfo, testServiceID);

            //Console.WriteLine($"Before suspension: {testServerDetails.Suspended}");

            //toggles testServerDetails.Suspended flag
            //apiClient.SuspendServer(authInfo, testServiceID, "For testing");
            //testServerDetails = apiClient.GetServerDetails(authInfo, testServiceID);

            //Console.WriteLine($"After suspension: {testServerDetails.Suspended}");

            //apiClient.UnsuspendServer(authInfo, testServiceID);
            //testServerDetails = apiClient.GetServerDetails(authInfo, testServiceID);

            //Console.WriteLine($"After unsuspension: {testServerDetails.Suspended}");

            //var powerCycleServerStatus = apiClient.PowerCycleServer(authInfo, testServiceID);

            //var requestKvmStatus = apiClient.RequestKvm(authInfo, testServiceID);

            //var requestRecoverySessionStatus = apiClient.RequestRecoverySession(authInfo, testServiceID);

            //test actions

            //var testTypesTest = apiClient.GetTestTypes();

            //int newTest = apiClient.AddTest(authInfo, testServiceID, "SwitchPort", "10.0.0.1", "");
            //int newTest = apiClient.AddTest(authInfo, testServiceID, "Http", "10.0.0.1", "");


            //var serverIDs = apiClient.GetAllServerIDs(authInfo);


            //var firstServer = serverDetails.ToList().First();

            //var firstServerDetail = apiClient.GetServerDetails(authInfo, firstServer.ServiceID);

            //var firstServerTests = apiClient.GetServerStatus(authInfo, firstServer.ServiceID);

            //var firstServerAlerts = apiClient.GetAlerts(authInfo, firstServer.ServiceID);

            //alert actions
            //alert on warn or alert on fail has to be true
            //init delay must be at least 5
            //repeat delay must be at least 15
            //destination must be a valaid phone no if alertType=SMS (i.e. +441234567890)
            //int newAlert = apiClient.AddAlert(authInfo, testServiceID, "SMS", "+441234567890", 5, 15, true, false);

            //forward dns domain actions
            //hosting type = Primary/Secondary
            //domain name must be unique
            //int newForwardDnsDomain = apiClient.AddForwardDnsDomain(authInfo, "codingchallengedomaintest1.com", "Primary", "127.0.0.1");
            //apiClient.DeleteForwardDnsDomain(authInfo, 3);

            //reverse dns entry actions
            //apiClient.SetReverseDnsEntry(authInfo, "10.0.0.2", "codingchallenge1.foo.com");
            //apiClient.SetReverseDnsEntry(authInfo, "10.0.0.2", "");

            int serverDetailIndex = 0;

            var allServerDetails = apiClient.GetAllServerDetails(authInfo);

            foreach (var allServerDetail in allServerDetails.ToList())
            {
                Console.WriteLine($"Server {serverDetailIndex + 1}");

                //server list
                Console.WriteLine($"Service ID: {allServerDetail.ServiceID}");
                Console.WriteLine($"Service type field: {allServerDetail.ServiceType}");
                Console.WriteLine($"Primary IP: {allServerDetail.PrimaryIP}");
                Console.WriteLine($"Location: {allServerDetail.Location}");
                Console.WriteLine($"Your reference: {allServerDetail.YourReference}");
                Console.WriteLine($"Status: {allServerDetail.Status}\n");

                //server details
                var serverStatuses = apiClient.GetServerStatus(authInfo, allServerDetail.ServiceID);

                int serverStatusesIndex = 0;

                Console.WriteLine("Service Statuses\n");
                foreach(var serverStatus in serverStatuses)
                {
                    Console.WriteLine($"Server status {serverStatusesIndex + 1}");
                    Console.WriteLine($"Status code: {serverStatus.StatusCode}");
                    Console.WriteLine($"Test Id: {serverStatus.TestId}");
                    Console.WriteLine($"Test name: {serverStatus.TestName}");

                    //Used for tests
                    Console.WriteLine($"Test arg1: {serverStatus.TestArg1}");
                    Console.WriteLine($"Monitored Ip: {serverStatus.MonitoredIp}");
                    Console.WriteLine($"Last updated: {serverStatus.LastUpdated.ToString("dd MMM yyyy")}\n");

                    serverStatusesIndex++;
                }

                var serverDetails = apiClient.GetServerDetails(authInfo, allServerDetail.ServiceID);

                Console.WriteLine("Server details\n");

                Console.WriteLine($"Bandwidth url base: {serverDetails.BandwidthUrlBase}");
                Console.WriteLine($"Your reference: {serverDetails.YourReference}");
                Console.WriteLine($"Location: {serverDetails.Location}");
                Console.WriteLine($"Primary IP: {serverDetails.PrimaryIP}");
                Console.WriteLine($"Service description: {serverDetails.ServiceDescription}\n");

                var testTypes = apiClient.GetTestTypes();

                int testTypesIndex = 0;

                Console.WriteLine("Test types\n");
                foreach (var testType in testTypes)
                {
                    Console.WriteLine($"Test type {testTypesIndex + 1}");
                    Console.WriteLine($"Test type: {testType}\n");

                    testTypesIndex++;
                }

                var alerts = apiClient.GetAlerts(authInfo, allServerDetail.ServiceID);

                int alertIndex = 0;

                Console.WriteLine("Alerts\n");
                foreach(var alert in alerts)
                {
                    Console.WriteLine($"Alert {alertIndex + 1}");
                    Console.WriteLine($"Alert type: {alert.AlertType}");
                    Console.WriteLine($"Destination: {alert.Destination}");
                    Console.WriteLine($"Initial delay: {alert.InitialDelay}");
                    Console.WriteLine($"Repeat delay: {alert.RepeatDelay}");
                    Console.WriteLine($"Alert on failure: {(alert.AlertOnFailure ? "Fail" : string.Empty)}\n");

                    alertIndex++;
                }

                //var testHistoryResults = apiClient.GetTestHistory(authInfo, allServerDetail.ServiceID, 1, 0);

                //var testIDs = serverStatuses.Select(x => x.TestId).ToList();

                //Console.WriteLine("Tests\n");
                //foreach (var testID in testIDs)
                //{
                //    var testHistoryResults = apiClient.GetTestHistory(authInfo, allServerDetail.ServiceID, testID, 0);

                //    int testHistoryResultIndex = 0;

                //    foreach (var testHistoryResult in testHistoryResults)
                //    {
                //        Console.WriteLine($"Test history result {testHistoryResultIndex + 1}");
                //        Console.WriteLine($"Date: {testHistoryResult.Date.ToString("dd MM yyy")}");
                //        Console.WriteLine($"Status code: {testHistoryResult.StatusCode}");
                //        Console.WriteLine($"Status detail: {testHistoryResult.StatusDetail}\n");

                //        testHistoryResultIndex++;
                //    }
                //}

                var bandwidthReport = apiClient.GetServerBandwidthReport(authInfo, allServerDetail.ServiceID, true);

                Console.WriteLine("Bandwidth reports\n");

                Console.WriteLine($"Last 4 Hours");
                Console.WriteLine($"BW4h In: {bandwidthReport.BW4hIn}");
                Console.WriteLine($"BW4h Out: {bandwidthReport.BW4hOut}");
                Console.WriteLine($"BW4h Total: {bandwidthReport.BW4hIn + bandwidthReport.BW4hOut}\n");

                Console.WriteLine($"Last 24 Hours");
                Console.WriteLine($"BW24h In: {bandwidthReport.BW24hIn}");
                Console.WriteLine($"BW24h Out: {bandwidthReport.BW24hOut}");
                Console.WriteLine($"BW24h Total: {bandwidthReport.BW24hIn + bandwidthReport.BW24hOut}\n");

                Console.WriteLine($"So far this month");
                Console.WriteLine($"BW so far this month in: {bandwidthReport.BWSofarThisMonthIn}");
                Console.WriteLine($"BW so far this month out: {bandwidthReport.BWSofarThisMonthOut}");
                Console.WriteLine($"BW so far this month total: {bandwidthReport.BWSofarThisMonthIn + bandwidthReport.BWSofarThisMonthOut}\n");

                Console.WriteLine($"Predicted this month (24h)");
                Console.WriteLine($"BW predicted 24h in: {bandwidthReport.BWPredicted24hIn}");
                Console.WriteLine($"BW predicted 24h out: {bandwidthReport.BWPredicted24hOut}");
                Console.WriteLine($"BW predicted 24h total: {bandwidthReport.BWPredicted24hIn + bandwidthReport.BWPredicted24hOut}\n");

                Console.WriteLine($"Predicted this month (14d)");
                Console.WriteLine($"BW predicted 24h in: {bandwidthReport.BWPredicted14dIn}");
                Console.WriteLine($"BW predicted 24h out: {bandwidthReport.BWPredicted14dOut}");
                Console.WriteLine($"BW predicted 24h total: {bandwidthReport.BWPredicted14dIn + bandwidthReport.BWPredicted14dOut}\n");

                var monthlyBandwidthReports = apiClient.GetMonthlyBandwidthReport(authInfo, allServerDetail.ServiceID, true);

                Console.WriteLine($"Monthly Bandwidth Reports\n");

                int monthlyBandwidthReportIndex = 0;

                foreach (var monthlyBandwidthReport in monthlyBandwidthReports)
                {
                    Console.WriteLine($"Monthly bandwidth report {monthlyBandwidthReportIndex + 1}");
                    Console.WriteLine($"Month: {monthlyBandwidthReport.Month.ToString("MMM yyyy")}");
                    Console.WriteLine($"BW in: {monthlyBandwidthReport.BWIn}");
                    Console.WriteLine($"BW out: {monthlyBandwidthReport.BWOut}");
                    Console.WriteLine($"BW total: {monthlyBandwidthReport.BWTotal}");
                    Console.WriteLine($"BW 95th percentile: {monthlyBandwidthReport.BW95thPercentile}\n");

                    monthlyBandwidthReportIndex++;
                }


                //Console.WriteLine($"Server {serverDetailIndex+1}");
                //Console.WriteLine($"Service ID: {serverDetail.ServiceID}");
                //Console.WriteLine($"Service Description: {serverDetail.ServiceDescription}");
                ////Console.WriteLine($"Service Description: {serverDetail.ServiceTypeField}");

                //var latestMonitor = apiClient.GetServerStatus(authInfo, serverDetail.ServiceID).ToList().Last();
                //Console.WriteLine($"Latest monitoring status : {latestMonitor.StatusCode}");

                //Console.WriteLine($"Bandwidth Url Base: {serverDetail.BandwidthUrlBase}");
                //Console.WriteLine($"IP Addresses: {string.Join(", ", serverDetail.IPAddresses)}");
                //Console.WriteLine($"Reverse Dns Entries: {string.Join(", ", serverDetail.ReverseDnsEntries ?? new ReverseDnsEntry[0])}\n");

                serverDetailIndex++;
            }

            //server details

            var forwardDnsDomains = apiClient.GetForwardDnsDomains(authInfo);

            int forwardDnsDomainIndex = 0;

            Console.WriteLine($"Forward Dns Domains\n");

            foreach (var forwardDnsDomain in forwardDnsDomains.ToList())
            {
                Console.WriteLine($"Forward Dns Domain {forwardDnsDomainIndex + 1}");
                Console.WriteLine($"Domain Id: {forwardDnsDomain.DomainId}");
                Console.WriteLine($"Domain Name: {forwardDnsDomain.DomainName}");
                Console.WriteLine($"Hosting type: {forwardDnsDomain.HostingType}");
                Console.WriteLine($"Expiry date: {forwardDnsDomain.ExpiryDate?.ToString("dd MM yy") ?? string.Empty}");
                Console.WriteLine($"Primary NS: {forwardDnsDomain.PrimaryNS}");
                Console.WriteLine($"Authority status: {forwardDnsDomain.AuthorityStatus}");
                Console.WriteLine($"Secondary transfer status: {forwardDnsDomain.SecondaryTransferStatus}\n");

                forwardDnsDomainIndex++;
            }

            var reverseDnsEntries = apiClient.GetReverseDnsEntries(authInfo);

            int reverseDnsIndex = 0;

            Console.WriteLine($"Reverse Dns Entries");

            foreach (var reverseDnsEntry in reverseDnsEntries.ToList())
            {
                Console.WriteLine($"Reverse DNS Entry {reverseDnsIndex + 1}");
                Console.WriteLine($"IP Address: {reverseDnsEntry.IPAddress}");
                Console.WriteLine($"Host Name: {reverseDnsEntry.HostName}\n");

                reverseDnsIndex++;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}

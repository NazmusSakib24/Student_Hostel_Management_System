using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Hostel_Management_System.Model;

namespace Student_Hostel_Management_System.Controller
{
    public class ServiceRequestController
    {
        ServiceRequests sr = new ServiceRequests();

        public void AddRequest(ServiceRequest r)
        {
            sr.AddRequest(r);
        }

        public void UpdateRequest(ServiceRequest r)
        {
            sr.UpdateRequest(r);
        }

        public void DeleteRequest(int requestID)
        {
            sr.DeleteRequest(requestID);
        }

        public ServiceRequest SearchRequest(int requestID)
        {
            return sr.SearchRequest(requestID);
        }

        public List<ServiceRequest> GetAllRequests()
        {
            return sr.GetAllRequests();
        }
    }
}

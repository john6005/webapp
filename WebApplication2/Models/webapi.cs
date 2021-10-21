using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class webapi
    {
		Version Control :  Version control is a system that records changes to a file or set of files over time so that you can recall specific versions later.
		   It helps to track the progress of each update .It enables all members of a team to collaborate from the most recently updated version.

why version control : 1.Traceability :It enables users to identify the development of the file through its various stages. 
		      2.Branching and Merging : Branching And Merging
Version control allows team members to work on the same document concurrently but independent of each other without affecting the other members

types:
------------------
1.Centralized Version Control Systems:The next major issue that people encounter is that they need to collaborate with developers on other systems. 

					  To deal with this problem, Centralized Version Control Systems (CVCSs) were developed.These systems (such as CVS,
									  Subversion, and Perforce) have a single server that contains all the versioned files, and a number of clients that
									  check out files from that central place.

drawback in cvcs: in sometimes server goes downsides.nobody can collabrate with eachother  or save versioned changes to anything they’re working on.
			  If the hard disk the central database is on becomes corrupted, and proper backups haven’t been kept.then result you should everything is lose.
==================================================================================================================================================================
Distributed Version Control system : clients don’t just check out the latest snapshot of the files; rather, they fully mirror the repository,
                                    including it   full history. Thus, if any server dies, and these systems were collaborating via that server, 
                                    any of the client repositories  can be copied back up to the server to restore it. Every clone is really a full backup 
                                    of all the data.
 
                                    

many of these systems deal pretty well with having several remote repositories they can work with, so you can collaborate with different groups of people 
in different ways simultaneously within the same project. 
=========================================================================================================================================================
GIT :Git is a version control system and it helps you track different versions of your code and collaborate with other developers.

* The major difference between Git and any other VCS is other vcs storing the data in list of files  but GIT Git doesn’t think of or store its data this way.
  Instead, Git thinks of its data more like a series of snapshots
===============================================================================================================================================================
 
Git has three main states that your files can reside in: modified, staged, and committed:

4 sub-directories:
============================
hooks/ : example scripts
info/ : exclude file for ignored patterns
objects/ : all "objects"
refs/ : pointers to commit objects
===================================================
4 files:
==============================================
HEAD : current branch
config : configuration options
description
index : staging area
Here "object" includes:

blobs(files)
trees(directories)
commits(reference to a tree, parent commit, etc)

==============================================================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsapp_Api.Models
{
    public class whatsapp
    {
        public string username { get; set; }
        public string password { get; set; }
        public string mobile_no { get; set; }
        public string campaign_name { get; set; }
        public string message { get; set; }
    }
}
=========================================================================
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Whatsapp_Api.Models;

namespace Whatsapp_Api.Controllers
{
    public class HomeController : ApiController
    {
        public string Index()
        {

            whatsapp whatsappReqobj = new whatsapp()
            {
                username = "travelmerry",
                password = "l(nh^d@1@3$5^",
                mobile_no = "6786662853",
                campaign_name = "API",
                message = "Hi how are you doing."

            };

            string RequestData = JsonConvert.SerializeObject(whatsappReqobj);

            //*************************************************************************
            // ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;                      
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            //**************************************************************************


            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://182.75.84.114/admin/Sendwhatsapp/insert_whatsapp_api1");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(RequestData);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var searchResult = streamReader.ReadToEnd();
            }

            return "";
        }
    }
}
==================================================================================================================
{
	"info": {
		"_postman_id": "f5b4a5c4-aadb-4b54-a9ca-846640612e92",
		"name": "travelmerry",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
	},
	"item": [
		{
			"name": "http://182.75.84.114/admin/Sendwhatsapp/insert_whatsapp_api1?",
			"request": {
				"method": "POST",
				"header": [
					{
						"key": "content-type",
						"type": "text",
						"value": "application/json"
					}
				],
				"body": {
					"mode": "formdata",
					"formdata": [
						{
							"key": "username",
							"value": "travelmerry",
							"type": "text"
						},
						{
							"key": "password",
							"value": "123456",
							"type": "text"
						},
						{
							"key": "mobile_no",
							"value": "918878599599",
							"type": "text"
						},
						{
							"key": "message",
							"value": "91 add test8",
							"type": "text"
						},
						{
							"key": "uploaded1",
							"value": "1",
							"type": "text"
						},
						{
							"key": "uploaded2",
							"value": "2",
							"type": "text"
						},
						{
							"key": "uploaded3",
							"value": "3",
							"type": "text"
						}
					]
				},
				"url": {
					"raw": "http://182.75.84.114/admin/Sendwhatsapp/insert_whatsapp_api1?",
					"protocol": "http",
					"host": [
						"182",
						"75",
						"84",
						"114"
					],
					"path": [
						"admin",
						"Sendwhatsapp",
						"insert_whatsapp_api1"
					],
					"query": [
						{
							"key": "",
							"value": null
						}
					]
				},
				"description": "Postman collection"
			},
			"response": []
		}
	]
}






























    }

}
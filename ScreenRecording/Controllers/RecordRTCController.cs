﻿using System;
using System.IO;
using System.Web.Mvc;

namespace RecordRTC_to_ASPNETMVC.Controllers
{
    // www.MuazKhan.com
    // www.WebRTC-Experiment.com
    // RecordRTC.org
    public class RecordRTCController : Controller
    {
        // ---/RecordRTC/
        public ActionResult Index()
        {
            return View();
        }

        // ---/RecordRTC/PostRecordedAudioVideo
        [HttpPost]
        public ActionResult PostRecordedAudioVideo()
        {
            foreach (string upload in Request.Files)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var file = Request.Files[upload];
                if (file == null) continue;

                file.SaveAs(Path.Combine(path, Request.Form[0]));
            }
            return Json(Request.Form[0]);
        }

        // ---/RecordRTC/DeleteFile
        [HttpPost]
        public ActionResult DeleteFile()
        {
            var fileUrl =  Server.MapPath("~/Uploads/") + Request.Form["delete-file"] + ".webm";
            new FileInfo(fileUrl).Delete();
            return Json(true);
        }
        public ActionResult Screen()
        {
            return View();
        }

    }
}
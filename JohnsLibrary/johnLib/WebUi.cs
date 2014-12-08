using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.ObjectModel;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace johnLib
{
    public class WebUI
    {
        public static void FillList(ListControl control, DataTable dt, string valueField, string textField, string selectedValue)
        {
            Collection<string> selectedValues = new Collection<string>();
            selectedValues.Add(selectedValue);
            FillList(control, dt, valueField, textField, selectedValues);
        }

        public static void FillList(ListControl control, DataTable dt, string valueField, string textField, Collection<string> selectedValues)
        {
            control.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem(dt.Rows[i][textField].ToString(),
                    dt.Rows[i][valueField].ToString());
                if (selectedValues.Contains(li.Value))
                {
                    li.Selected = true;
                }
                control.Items.Add(li);
            }
        }

        public static void FillList(ListControl control, DataTable dt, string valueField, string textField, DataTable selectedValues, string valueField1)
        {
            control.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem(dt.Rows[i][textField].ToString(),
                    dt.Rows[i][valueField].ToString());
                foreach (DataRow row in selectedValues.Rows)
                {
                    if (row[valueField1].ToString() == li.Value) li.Selected = true;
                }
                control.Items.Add(li);
            }
        }

        public static void FillList(ListControl control, DataTable dt, string valueField, string textField, Collection<string> selectedValues,
            string selectedItemAttribute, string selectedItemAttributeValue)
        {
            control.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem(dt.Rows[i][textField].ToString(),
                    dt.Rows[i][valueField].ToString());
                if (selectedValues.Contains(li.Value))
                {
                    li.Selected = true;
                    li.Attributes[selectedItemAttribute] = selectedItemAttributeValue;
                }
                control.Items.Add(li);
            }
        }

        public static string GeneratePagingText(string url, int totalRecords, int page, int pageSize)
        {
            if (totalRecords <= pageSize) return "";

            string c = url.IndexOf("?") >= 0 ? "&" : "?";
            string currentPage = "Page <b>" + page.ToString() + "</b> ";
            StringBuilder sbPrev = new StringBuilder();
            StringBuilder sbNext = new StringBuilder();
            StringBuilder sbPages = new StringBuilder();
            int pageCount = 0;
            if (totalRecords % pageSize == 0)
                pageCount = totalRecords / pageSize;
            else
                pageCount = totalRecords / pageSize + 1;

            if (page > 1)
                sbPrev.Append(
                    "<a href=\"" + url + c + "Page=1\">&lt;&lt;first</a> " +
                    "<a href=\"" + url + c + "Page=" + (page - 1).ToString() + "\">&lt;prev</a> ");

            if (pageSize * page < totalRecords)
                sbNext.Append(
                    "<a href=\"" + url + c + "Page=" + (page + 1).ToString() + "\">next&gt;</a> " +
                    "<a href=\"" + url + c + "Page=" + pageCount.ToString() + "\">last&gt;&gt;</a> ");


            for (int i = page - 5; i <= page + 5; i++)
            {
                if (i < 1 || i > pageCount) continue;

                if (i == page)
                {
                    sbPages.Append(" <b>" + i.ToString() + "</b> ");
                }
                else
                {
                    sbPages.Append(" <a href=\"" + url + c + "Page=" + i.ToString() + "\">" + i.ToString() + "</a> ");
                }
            }

            return sbPrev.ToString() + sbPages.ToString() + sbNext.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">The URL of the link e.g. Category.aspx</param>
        /// <param name="totalRecords">e.g. 16</param>
        /// <param name="currentPage">e.g. 2</param>
        /// <param name="pageSize">e.g. 10</param>
        /// <param name="pageFormat">e.g. </param>
        /// <param name="currentPageFormat">e.g. </param>
        /// <param name="prevFormat">e.g. </param>
        /// <param name="nextFormat">e.g. </param>
        /// <param name="headText">e.g. "<li>"</param>
        /// <param name="tailText">e.g. "</li>"</param>
        /// <returns></returns>
        public static string GeneratePagingText(string url, int totalRecords, int currentPage, int pageSize,
            string pageFormat, string currentPageFormat, string prevFormat, string nextFormat,
            string headText, string tailText)
        {
            string c = url.IndexOf("?") >= 0 ? "&" : "?";
            string strCurrentPage = currentPageFormat.Replace("{p}", currentPage.ToString());
            StringBuilder sbPrev = new StringBuilder(prevFormat);
            StringBuilder sbNext = new StringBuilder(nextFormat);
            StringBuilder sbPages = new StringBuilder();
            int pageCount = 0;

            if (currentPage > 1)
                sbPrev.Insert(0, headText + "<a href=\"" + url + c + "Page=" + (currentPage - 1).ToString() + "\">").Append("</a>" + tailText);
            else
                sbPrev.Insert(0, headText).Append(tailText);

            if (pageSize * currentPage < totalRecords)
                sbNext.Insert(0, headText + "<a href=\"" + url + c + "Page=" + (currentPage + 1).ToString() + "\">").Append("</a>" + tailText);
            else
                sbNext.Insert(0, headText).Append(tailText);

            if (totalRecords % pageSize == 0)
                pageCount = totalRecords / pageSize;
            else
                pageCount = totalRecords / pageSize + 1;
            for (int i = 1; i <= pageCount; i++)
            {
                if (i == currentPage)
                {
                    sbPages.Append(headText + strCurrentPage + tailText);
                }
                else
                {
                    sbPages.Append(headText + "<a href=\"" + url + c + "Page=" + i.ToString() + "\">" + pageFormat.Replace("{p}", i.ToString()) + "</a>" + tailText);
                }
            }

            return sbPrev.ToString() + sbPages.ToString() + sbNext.ToString();
        }

        public static string GeneratePagingText(string url, int totalRecords, int page, int pageSize,
            string prevImageUrl, string nextImageUrl)
        {
            string c = url.IndexOf("?") >= 0 ? "&" : "?";
            StringBuilder sbPrev = new StringBuilder("<img src='" + prevImageUrl + "' border='0'>");
            StringBuilder sbNext = new StringBuilder("<img src='" + nextImageUrl + "' border='0'>");
            StringBuilder sbPages = new StringBuilder();

            if (page > 1)
                sbPrev.Insert(0, "<a href=\"" + url + c + "Page=" + (page - 1).ToString() + "\">").Append("</a> ");
            if (pageSize * page < totalRecords)
                sbNext.Insert(0, "<a href=\"" + url + c + "Page=" + (page + 1).ToString() + "\">").Append("</a> ");

            return sbPrev.ToString() + "&nbsp;&nbsp;" + sbNext.ToString();
        }

        /// <summary>
        /// format = "{t} products found. Displaying {s} - {e}"
        /// </summary>
        /// <param name="format"></param>
        /// <param name="totalRecords"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static string GeneratingResultsText(string format, int totalRecords, int currentPage, int pageSize)
        {
            int start = (currentPage - 1) * pageSize + 1;
            int end = 0;
            if (currentPage * pageSize > totalRecords)
                end = totalRecords;
            else
                end = currentPage * pageSize;

            StringBuilder sb = new StringBuilder(format);
            sb.Replace("{t}", totalRecords.ToString());
            sb.Replace("{s}", start.ToString());
            sb.Replace("{e}", end.ToString());

            return sb.ToString();
        }

        public static string GeneratePagingText(string url, int totalRecords, int page, int pageSize, int style)
        {
            string c = url.IndexOf("?") >= 0 ? "&" : "?";
            string currentPage = "Page <b>" + page.ToString() + "</b> ";
            StringBuilder sbPrev = new StringBuilder("&lt;prev");
            StringBuilder sbNext = new StringBuilder("next&gt;");
            StringBuilder sbPages = new StringBuilder();
            int pageCount = 0;
            if (page > 1)
                sbPrev.Insert(0, "<a href=\"" + url + c + "Page=" + (page - 1).ToString() + "\">").Append("</a> ");
            if (pageSize * page < totalRecords)
                sbNext.Insert(0, "<a href=\"" + url + c + "Page=" + (page + 1).ToString() + "\">").Append("</a> ");
            if (totalRecords % pageSize == 0)
                pageCount = totalRecords / pageSize;
            else
                pageCount = totalRecords / pageSize + 1;
            for (int i = 1; i <= pageCount; i++)
            {
                if (i == page)
                {
                    sbPages.Append(" <b>" + i.ToString() + "</b> ");
                }
                else
                {
                    sbPages.Append(" <a href=\"" + url + c + "Page=" + i.ToString() + "\">" + i.ToString() + "</a> ");
                }
            }

            //return sbPrev.ToString() + sbPages.ToString() + sbNext.ToString();
            return sbPages.ToString();
        }

        public static string ToHTML(string s)
        {
            return s.Replace("\n", "<br>");
        }

        public static string DisplayImage(string path, string otherAttributes)
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                return "<img src='" + path + "?r=" + DateTime.Now.ToOADate().ToString() + "' " + otherAttributes + " />";
            }
            else
            {
                return "";
            }
        }

        public static string DisplayImage(string path)
        {
            return DisplayImage(path, "");
        }

        public static void Export(System.Web.HttpResponse response, byte[] binary, string fileName, string contentType)
        {
            response.Buffer = false;
            response.ClearHeaders();
            response.ContentType = contentType;
            response.AddHeader("Content-Disposition",
                     "attachment; filename=" + fileName);
            //
            //Code for streaming the object while writing
            const int ChunkSize = 1024;
            byte[] buffer = new byte[ChunkSize];
            MemoryStream ms = new MemoryStream(binary);
            int SizeToWrite = ChunkSize;

            for (int i = 0; i < binary.GetUpperBound(0) - 1; i = i + ChunkSize)
            {
                if (!response.IsClientConnected) return;
                if (i + ChunkSize >= binary.Length)
                    SizeToWrite = binary.Length - i;
                byte[] chunk = new byte[SizeToWrite];
                ms.Read(chunk, 0, SizeToWrite);
                response.BinaryWrite(chunk);
                response.Flush();
            }
            response.Close();
        }

        public static string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                return source;
            }
        }

        public static void DisplayImage(byte[] content, System.Web.HttpResponse response, string w, string h)
        {
            if (content == null || content.Length == 0)
            {
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(1, 1);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 1, 1);
                g.Flush();
                g.Dispose();
                image.Save(response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                try
                {

                    response.ContentType = "image/jpeg";
                    Stream inStream = new MemoryStream(content);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(inStream);

                    if (string.IsNullOrEmpty(w) == false && string.IsNullOrEmpty(h) == false)
                    {
                        ImageUtils.Crop(img, Convert.ToInt32(w), Convert.ToInt32(h), ImageUtils.AnchorPosition.Center).Save(
                            response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(WebUI.ThumbnailCallback);
                        //img.GetThumbnailImage(Convert.ToInt32(w), Convert.ToInt32(h), myCallback, System.IntPtr.Zero).
                        //    Save(response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (string.IsNullOrEmpty(w) == false)
                    {
                        ImageUtils.ScaleByWidth(img, Convert.ToInt32(w))
                            .Save(response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        img.Save(response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    inStream.Close();
                    img.Dispose();
                }
                catch
                {
                    System.Drawing.Bitmap image = new System.Drawing.Bitmap(1, 1);
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                    g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 1, 1);
                    g.Flush();
                    g.Dispose();
                    image.Save(response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        private static bool ThumbnailCallback()
        {
            return false;
        }

        public static void Download(byte[] content, string fileName, string mimeType, System.Web.HttpResponse response)
        {
            response.Buffer = false;
            response.ClearHeaders();
            response.ContentType = mimeType;
            response.AddHeader("Content-Disposition",
                     "attachment; filename=" + fileName);
            
            //Code for streaming the object while writing
            const int ChunkSize = 1024;
            byte[] buffer = new byte[ChunkSize];
            byte[] binary = content as byte[];
            MemoryStream ms = new MemoryStream(binary);
            int SizeToWrite = ChunkSize;

            for (int i = 0; i < binary.GetUpperBound(0) - 1; i = i + ChunkSize)
            {
                if (!response.IsClientConnected) return;
                if (i + ChunkSize >= binary.Length)
                    SizeToWrite = binary.Length - i;
                byte[] chunk = new byte[SizeToWrite];
                ms.Read(chunk, 0, SizeToWrite);
                response.BinaryWrite(chunk);
                response.Flush();
            }
            response.Close();
        }

        public static void Download(string path, string fileName, string mimeType, System.Web.HttpResponse response)
        {
            response.Buffer = false;
            response.ClearHeaders();
            response.ContentType = mimeType;
            response.AddHeader("Content-Disposition",
                     "attachment; filename=" + fileName);
            //
            //Code for streaming the object while writing
            const int ChunkSize = 1024;
            byte[] buffer = new byte[ChunkSize];
            byte[] binary = File.ReadAllBytes(path);
            MemoryStream ms = new MemoryStream(binary);
            int SizeToWrite = ChunkSize;

            for (int i = 0; i < binary.GetUpperBound(0) - 1; i = i + ChunkSize)
            {
                if (!response.IsClientConnected) return;
                if (i + ChunkSize >= binary.Length)
                    SizeToWrite = binary.Length - i;
                byte[] chunk = new byte[SizeToWrite];
                ms.Read(chunk, 0, SizeToWrite);
                response.BinaryWrite(chunk);
                response.Flush();
            }
            response.Close();
        }

        public static void AddMetaTags(System.Web.UI.HtmlControls.HtmlHead header, string metaName, string metaContent)
        {
            try
            {
                foreach (Control control in header.Controls)
                {
                    try
                    {
                        if (((HtmlControl)control).Attributes["name"] == metaName)
                        {
                            header.Controls.Remove(control);
                            break;
                        }
                    }
                    catch { }
                }
                HtmlMeta meta = new HtmlMeta();
                meta.Name = metaName;
                meta.Content = metaContent;
                header.Controls.Add(meta);
            }
            catch { }
        }

        public static void UpdateTitle(System.Web.UI.HtmlControls.HtmlHead header, string value)
        {
            try
            {
                foreach (HtmlControl control in header.Controls)
                {
                    if (control.TagName.ToLower() == "title")
                    {
                        header.Controls.Remove(control);
                        break;
                    }
                }
                HtmlTitle title = new HtmlTitle();
                title.Text = value;
                header.Controls.Add(title);
            }
            catch { }
        }

        public static void ImageSaveAs(byte[] content, string path, string w, string h)
        {
            if (content == null || content.Length == 0)
            {
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(1, 1);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 1, 1);
                g.Flush();
                g.Dispose();
                image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                try
                {

                    //response.ContentType = "image/jpeg";
                    Stream inStream = new MemoryStream(content);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(inStream);

                    if (string.IsNullOrEmpty(w) == false && string.IsNullOrEmpty(h) == false)
                    {
                        ImageUtils.Crop(img, Convert.ToInt32(w), Convert.ToInt32(h), ImageUtils.AnchorPosition.Center).Save(
                            path, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(WebUI.ThumbnailCallback);
                        //img.GetThumbnailImage(Convert.ToInt32(w), Convert.ToInt32(h), myCallback, System.IntPtr.Zero).
                        //    Save(response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (string.IsNullOrEmpty(w) == false)
                    {
                        ImageUtils.ScaleByWidth(img, Convert.ToInt32(w))
                            .Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    inStream.Close();
                    img.Dispose();
                }
                catch
                {
                    System.Drawing.Bitmap image = new System.Drawing.Bitmap(1, 1);
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                    g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 1, 1);
                    g.Flush();
                    g.Dispose();
                    image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

    }
}

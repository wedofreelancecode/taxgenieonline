<%@ Page Title="Home" Language="C#" MasterPageFile="~/TaxGenie.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="TaxGenieOnline.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <script language="javascript" src="scripts/slides.min.jquery.js" type="text/javascript"></script>
    <script language="javascript" src="scripts/slides.jquery.js" type="text/javascript"></script>
    <div class="cl22 fleft">
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle2">
                <div class="blue">
                    Tax Update</div>
                <div class="brdhdsblue">
                </div>
                <div class="ab1" style="font-size:12px;font-weight:bold;" >
                    <asp:Repeater ID="dlTaxUpdate" runat="server">
                        <ItemTemplate>
                        <br />
                            <a style="font-size:12px;font-weight:bold;color:#08F" href='/ViewTaxUpdate.aspx?Id=<%# Eval("Id") %>'>
                            <img src='<%# Eval("ImgPath") %>' alt="" style="margin-top:-16px"  width="180" height="140" class="txtwrap" /><%# Eval("Title") %>
                            </a>
                            <br /><br />
                            Published:<%# Eval("DateTime") %>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <span class="more"><a href="/ShowTaxUpdates.aspx">Previous Tax Updates</a></span>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle2">
                <div class="blue">
                    Editor's Desk</div>
                <div class="brdhdsblue">
                </div>
                <div class="ab1">
                        <asp:Repeater ID="dlEditorDesk" runat="server">
                            <ItemTemplate>
                                <a class="rss-item" style="font-size:12px;font-weight:bold;color:#08F" href='/ViewContent.aspx?Id=<%# Eval("Id") %>'>
                                <img src='<%# Eval("ImgPath") %>' alt=""  width="85" height="70" class="txtwrap" />
                                    <%# Eval("Title") %>
                                    ...</a>
                            </ItemTemplate>
                        </asp:Repeater>
                </div>
                <span class="more"><a href="/ShowContents.aspx?CType=Editor Desk">more...</a></span>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
        <div class="contentbox">
            <div class="contentboxadd">
                <div class="ab1">
                    <div>
                        <img src="images/psslogo.png" width="87" height="70" style="float: right; margin: 0px 0px 5px 20px;" />
                        <script type="text/javascript">
                            var delay = 2000;
                            var maxsteps = 30;
                            var stepdelay = 40;
                            var startcolor = new Array(255, 255, 255);
                            var endcolor = new Array(0, 0, 0);
                            var fcontent = new Array();
                            begintag = '<div style="font:bold 16px Trebuchet MS italic; padding:15px 20px 5px 30px;">';
                            fcontent[0] = "<span style='color:#f16528;'>Establishing a goal driven metrics</span>";
                            fcontent[1] = "Implementing good requirements <br />engineering practices";
                            fcontent[2] = "<span style='color:green;'>Capturing and quantifying <br />process productivity</span>";
                            fcontent[3] = "Implementing risk management early";
                            closetag = '</div>';
                            var fwidth = '400px';
                            var fheight = '80px';
                            var fadelinks = 1;
                            var ie4 = document.all && !document.getElementById;
                            var DOM2 = document.getElementById;
                            var faderdelay = 0;
                            var index = 0;
                            function changecontent() {
                                if (index >= fcontent.length)
                                    index = 0
                                if (DOM2) {
                                    document.getElementById("fscroller").style.color = "rgb(" + startcolor[0] + ", " + startcolor[1] + ", " + startcolor[2] + ")"
                                    document.getElementById("fscroller").innerHTML = begintag + fcontent[index] + closetag
                                    if (fadelinks)
                                        linkcolorchange(1);
                                    colorfade(1, 15);
                                }
                                else if (ie4)
                                    document.all.fscroller.innerHTML = begintag + fcontent[index] + closetag;
                                index++
                            }
                            function linkcolorchange(step) {
                                var obj = document.getElementById("fscroller").getElementsByTagName("A");
                                if (obj.length > 0) {
                                    for (i = 0; i < obj.length; i++)
                                        obj[i].style.color = getstepcolor(step);
                                }
                            }
                            var fadecounter;
                            function colorfade(step) {
                                if (step <= maxsteps) {
                                    document.getElementById("fscroller").style.color = getstepcolor(step);
                                    if (fadelinks)
                                        linkcolorchange(step);
                                    step++;
                                    fadecounter = setTimeout("colorfade(" + step + ")", stepdelay);
                                } else {
                                    clearTimeout(fadecounter);
                                    document.getElementById("fscroller").style.color = "rgb(" + endcolor[0] + ", " + endcolor[1] + ", " + endcolor[2] + ")";
                                    setTimeout("changecontent()", delay);
                                }
                            }
                            function getstepcolor(step) {
                                var diff
                                var newcolor = new Array(3);
                                for (var i = 0; i < 3; i++) {
                                    diff = (startcolor[i] - endcolor[i]);
                                    if (diff > 0) {
                                        newcolor[i] = startcolor[i] - (Math.round((diff / maxsteps)) * step);
                                    } else {
                                        newcolor[i] = startcolor[i] + (Math.round((Math.abs(diff) / maxsteps)) * step);
                                    }
                                }
                                return ("rgb(" + newcolor[0] + ", " + newcolor[1] + ", " + newcolor[2] + ")");
                            }
                            if (ie4 || DOM2)
                                document.write('<div id="fscroller" style="' + fwidth + ';height:' + fheight + '"></div>');
                            if (window.addEventListener)
                                window.addEventListener("load", changecontent, false)
                            else if (window.attachEvent)
                                window.attachEvent("onload", changecontent)
                            else if (document.getElementById)
                                window.onload = changecontent
                        </script>
                    </div>
                </div>
            </div>
        </div>
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle2">
                <div class="blue">
                    Case Analysis</div>
                <div class="brdhdsblue">
                </div>
                <div class="ab1">
                    <ol>
                        <asp:Repeater ID="dlCaseAnalysis" runat="server">
                            <ItemTemplate>
                                <li><a style="font-size:12px;font-weight:bold;color:#08F" href='/ViewContent.aspx?Id=<%# Eval("Id") %>'>
                                    <%# Eval("Title") %>
                                    ...</a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ol>
                </div>
                <span class="more"><a href="/ShowContents.aspx?CType=Case Analysis">more...</a></span>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>

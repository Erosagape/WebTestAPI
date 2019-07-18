<!DOCTYPE html>
<html>
<head>
    <title>Tawan Menu</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="~/Content/Site.css">
    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <script type="text/javascript" src="~/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="~/Scripts/Module/Message.js"></script>
</head>
<body style="background:#e6e6e6;color:black;">
    <!-- Sidebar -->
    <div class="w3-sidebar w3-bar-block w3-animate-left" style="display:none;z-index:5" id="mySidebar">
        <div class="w3-sidebar w3-bar-block w3-indigo w3-card" style="width:250px;">
            <div style="width:100%;text-align:center;background-color:white">
                <img src="~/Resources/logo-tawan.jpg" onclick="w3_open()" style="width:150px;padding:5px 5px 5px 5px;" />
            </div>
            <div class="w3-bar-item w3-button" onclick="w3_accordion('mnuMkt')">
                Marketing Works
            </div>
            <div id="mnuMkt" class="w3-hide w3-pale-green w3-card-4">
                <a href="#" class="w3-bar-item w3-button">- Quotation</a>
                <a href="#" class="w3-bar-item w3-button">- Approve Quotation</a>
            </div>
            <div class="w3-bar-item w3-button" onclick="w3_accordion('mnuCS')">
                CS Works
            </div>
            <div id="mnuCS" class="w3-hide w3-light-grey w3-card-4">
                <a href="#" class="w3-bar-item w3-button">- Create Job</a>
                <a href="#" class="w3-bar-item w3-button">- List Job</a>
            </div>
            <div class="w3-bar-item w3-button" onclick="w3_accordion('mnuApp')">
                Approving
            </div>
            <div id="mnuApp" class="w3-hide w3-pale-yellow w3-card-4">
                <a href="#" class="w3-bar-item w3-button">- Approve Advance</a>
                <a href="#" class="w3-bar-item w3-button">- Approve Clearing</a>
            </div>
            <div class="w3-bar-item w3-button" onclick="w3_accordion('mnuFin')">
                Finance Works
            </div>
            <div id="mnuFin" class="w3-hide w3-pale-blue w3-card-4">
                <a href="#" class="w3-bar-item w3-button">- Payment Advance</a>
                <a href="#" class="w3-bar-item w3-button">- Payment Bill</a>
                <a href="#" class="w3-bar-item w3-button">- Receive Clearing</a>
                <a href="#" class="w3-bar-item w3-button">- Receive Invoice</a>
                <a href="#" class="w3-bar-item w3-button">- Cheque Management</a>
                <a href="#" class="w3-bar-item w3-button">- Petty Cash</a>
                <a href="#" class="w3-bar-item w3-button">- Earnest Clearing</a>
            </div>
            <div class="w3-bar-item w3-button" onclick="w3_accordion('mnuAcc')">
                Account Works
            </div>
            <div id="mnuAcc" class="w3-hide w3-pale-red w3-card-4">
                <a href="#" class="w3-bar-item w3-button">- Vouchers</a>
                <a href="#" class="w3-bar-item w3-button">- Invoice</a>
                <a href="#" class="w3-bar-item w3-button">- Billing</a>
                <a href="#" class="w3-bar-item w3-button">- Receipts</a>
                <a href="#" class="w3-bar-item w3-button">- Tax-invoice</a>
                <a href="#" class="w3-bar-item w3-button">- Payments Bill</a>
                <a href="#" class="w3-bar-item w3-button">- Credit/Debit Note</a>
                <a href="#" class="w3-bar-item w3-button">- Journal Entry</a>
                <a href="#" class="w3-bar-item w3-button">- Adjustments</a>
            </div>
        </div>
    </div>
    <div class="w3-overlay w3-animate-opacity" onclick="w3_close()" style="cursor:pointer" id="myOverlay"></div>
    <div style="display:flex;flex-direction:column;margin-bottom:100px;">
        <div style="background-color:white;display:flex">
            <div style="flex:20%">
                <img src="~/Resources/logo-tawan.jpg" onclick="w3_open()" style="width:150px;float:left;padding:5px 5px 5px 5px;" />
            </div>
            <div style="flex:75%;text-align:right;align-self:center;padding-right:10px">
                Tawan Technology
            </div>
            <div style="flex:5%;text-align:right;align-self:center;padding-right:10px">
                <select id="cboLang">
                    <option value="0">THA</option>
                    <option value="1">ENG</option>
                </select>
            </div>
        </div>
        <div class="w3-container" style="margin-bottom:10px">
            <!-- Page Content -->
            @RenderBody
        </div>
        <div id="dvCommands" class="w3-card w3-white" style="bottom:50px;position:fixed;line-height:50px;width:100%;padding-left:5px;">
            <a href="#" class="btn btn-outline-secondary" id="btnAdd" onclick="AddData()" style="width:100px;">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>New</b>
            </a>
            <a href="#" class="btn btn-outline-success" id="btnSave" onclick="SaveData()"  style="width:100px;">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b>Save</b>
            </a>
            <a href="#" class="btn btn-outline-danger" id="btnDelete" onclick="DeleteData()"  style="width:100px;">
                <i class="fa fa-lg fa-trash"></i>&nbsp;<b>Delete</b>
            </a>
            <a href="#" class="btn btn-outline-info" id="btnPrint" onclick="PrintData()"  style="width:100px;">
                <i class="fa fa-lg fa-print"></i>&nbsp;<b>Print</b>
            </a>
            <a href="#" class="btn btn-outline-dark" id="btnCancel" onclick="CancelData()"  style="width:100px;">
                <i class="fa fa-lg fa-close"></i>&nbsp;<b>Cancel</b>
            </a>
            <a href="#" class="btn btn-outline-primary" id="btnSearch" onclick="FindData()"  style="width:100px;">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Search</b>
            </a>
        </div>
    </div>
    <div style="text-align:center;bottom:0;position:fixed;line-height:50px;width:100%;display:inline-block;background-color:indigo;color:white;">
        Tawan Technology Co.ltd &copy;2019
    </div>
    <script type="text/javascript">
    document.getElementById("cboLang").onchange = function () {
        defaultLanguage = document.getElementById("cboLang").value;
    }
    function w3_open() {
        document.getElementById("mySidebar").style.display = "block";
        document.getElementById("myOverlay").style.display = "block";
    }
    function w3_close() {
        document.getElementById("mySidebar").style.display = "none";
        document.getElementById("myOverlay").style.display = "none";
    }
    function w3_accordion(id) {
        var x = document.getElementById(id);
        if (x.className.indexOf("w3-show") == -1) {
            x.className += " w3-show";
        } else {
            x.className = x.className.replace(" w3-show", "");
        }
    }
    </script>
</body>
</html> 
@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<div class="container-fluid">
    <div class="row">
        <div class="col-sm-4">
            <label>Citizen ID</label>
            <br />
            <div style="display:flex">
                <input type="text" id="txtCitizenId" class="form-control" />
                <input type="button" value="..." id="btnShowId" class="btn btn-outline-primary w3-white" style="width:40px" />
            </div>
        </div>
        <div class="col-sm-3">
            <label>Citizen Title</label>
            <br />
            <select id="txtCitizenTitle" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-5">
            <label>Citizen Name</label><br />
            <input type="text" id="txtCitizenName" class="form-control" />
        </div>
    </div>
</div>
<script type="text/javascript" src="~/Scripts/Module/Home/Index.js"></script>

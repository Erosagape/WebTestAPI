let obj = {};
let list = [];

SetEvents();

function SetEvents() {
    LoadTitle();
    let btnShowId = document.getElementById("btnShowId");
    btnShowId.onclick = () => {
        ShowData();
    }
}
function LoadTitle() {
    let selectTitle = document.getElementById("txtCitizenTitle");
    let values = ["นาย", "นาง", "นางสาว", "เด็กชาย", "เด็กหญิง"];
    for (let val of values) {
        let op = document.createElement("option");
        op.text = val;
        selectTitle.appendChild(op);
    }
}
function AddData() {
    document.querySelector("#txtCitizenId").value = "";
    document.querySelector("#txtCitizenTitle").value = "";
    document.querySelector("#txtCitizenName").value = "";
    LoadData();
}
function CheckData() {
    let bPass = true;
    LoadData();
    if (obj.CitizenId == '') {
        customMessage('กรุณาใส่เลขประจำตัวประชาชน','Please enter Citizen Id');
        bPass = false;
    }
    if (obj.CitizenTitle == '') {
        customMessage('กรุณาใส่คำนำหน้า','Please Enter Citizen Title');
        bPass = false;
    }
    if (obj.CitizenName == '') {
        customMessage('กรุณาระบุชื่อ','Please Enter Citizen Name');
        bPass = false;
    }
    return bPass;
}
function LoadData() {
    obj= {
        CitizenId: document.querySelector("#txtCitizenId").value,
        CitizenTitle: document.querySelector("#txtCitizenTitle").value,
        CitizenName: document.querySelector("#txtCitizenName").value,
    }
}
function SaveData() {
    if (CheckData() == false) return;
    let index = GetDataIndex();
    if (index < 0) {
        list.push(obj);
        msgAddComplete();
    } else {
        if (confirm("ต้องการแก้ไขข้อมูลหรือไม่") == true) {
            list[index].CitizenId = obj.CitizenId;
            list[index].CitizenTitle = obj.CitizenTitle;
            list[index].CitizenName = obj.CitizenName;
            msgUpdateComplete();
        }
    }
}
function DeleteData() {
    let index = GetDataIndex();
    if (index >=0) {
        list.splice(index, 1);        
        msgDeleteComplete();
        AddData();
    } else {
        msgDataNotFound();
        AddData();
    }
}
function CancelData() {

    document.querySelector("#txtCitizenId").value = obj.CitizenId;
    document.querySelector("#txtCitizenTitle").value = obj.CitizenTitle;
    document.querySelector("#txtCitizenName").value = obj.CitizenName;

    msgDataCancel();
}
function PrintData() {
    let jsonText = JSON.stringify(obj);
    alert(jsonText);
}
function ShowData() {    
    let jsonText = JSON.stringify(list);
    alert(jsonText);
}
function GetDataIndex() {
    let id = document.querySelector("#txtCitizenId").value;
    let index = list.findIndex(x => x.CitizenId === id);
    return index;
}
function FindData() {
    let idx = GetDataIndex();
    let data = list[idx];
    if (data !== undefined) {
        document.querySelector("#txtCitizenId").value = data.CitizenId;
        document.querySelector("#txtCitizenTitle").value = data.CitizenTitle;
        document.querySelector("#txtCitizenName").value = data.CitizenName;
        LoadData();
        msgDataFound();
    } else {
        AddData();
        msgDataNotFound();
    }
}
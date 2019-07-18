function LanguageList() {
    return ["TH", "EN"]
}
var defaultLanguage = 0;
function msgAddComplete() {
    return alert((["เพิ่มข้อมูลเรียบร้อย", "Add Data Complete"])[defaultLanguage]);
}
function msgUpdateComplete() {
    return alert((["ปรับปรุงข้อมูลเรียบร้อย", "Update Data Complete"])[defaultLanguage]);
}
function msgDeleteComplete() {
    return alert((["ลบข้อมูลเรียบร้อย", "Delete Data Complete"])[defaultLanguage]);
}
function msgDataNotFound() {
    return alert((["ไม่พบช้อมูล", "Data Not Found"])[defaultLanguage]);
}
function msgDataFound() {
    return alert((["พบช้อมูล", "Data Found"])[defaultLanguage]);
}
function msgDataCancel() {
    return alert((["ยกเลิกช้อมูลแล้ว", "Data Cancelled"])[defaultLanguage]);
}
function customMessage(msg1, msg2) {
    return alert(([msg1, msg2])[defaultLanguage]);
}
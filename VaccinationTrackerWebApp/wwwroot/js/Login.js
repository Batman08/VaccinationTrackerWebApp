/// <reference path="Request.ts"/>
const txtUsername = document.querySelector('#txtUsername');
const divLoginMessage = document.querySelector('#divLoginMessage');
//function verifyLogin(e: Event): void {
//    if (e.preventDefault) e.preventDefault();
//    let url = '/Login?handler=LoginProcess' as string;
//    /*let dataToServer = `Username=` + txtUsername.value;*/
//    let dataToServer = { Username: txtUsername.value };
//    postData(url, JSON.stringify(dataToServer), null);
//}
function verifyLogin(e) {
    if (e.preventDefault)
        e.preventDefault();
    divLoginMessage.innerHTML = '';
    const submittedValue = txtUsername.value;
    localStorage.setItem("medicalPersonId", submittedValue);
    let dataToServer = `Username=${submittedValue}`;
    postData('Login?handler=ProcessLogin', dataToServer, (data) => {
        let response = JSON.parse(data);
        if (response.value === "DemoAdministrator") {
            window.location.href = "AdminReports";
        }
        else if (response.value === "") {
            displayLoginErrorMessage();
        }
        else if (response.value !== null) {
            window.location.href = "VaccinatePatient";
        }
    });
}
function displayLoginErrorMessage() {
    const resultHtml = '<div class="alert alert-danger" role="alert"><i class="fas fa-exclamation-triangle"></i> Pleast select a valid login.</div>';
    divLoginMessage.innerHTML = resultHtml;
}
const formLogin = document.querySelector("#formLogin");
formLogin.onsubmit = verifyLogin;
//# sourceMappingURL=Login.js.map
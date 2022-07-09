/// <reference path="Request.ts"/>
const medicalPersonDetails = document.querySelector('#medicalPersonDetails');
const medicalPersonContact = document.querySelector('#medicalPersonContact');
console.log(localStorage.getItem("medicalPersonId"));
function getMedicalPersonData() {
    let medicalPersonId = localStorage.getItem("medicalPersonId");
    //let medicalPersonId = parseInt(localStorage.getItem("medicalPersonId")) as number;
    let url = '/VaccinatePatient?handler=MedicalPersonId';
    let dataToServer = `MedicalPersonId=${medicalPersonId}`;
    postData(url, dataToServer, (data) => {
        let response = JSON.parse(data);
        let medicalPersonData = response.medicalPersonData[0];
        console.log(response);
        medicalPersonDetails.innerHTML = `<i class="fas fa-user"></i> ${medicalPersonData.firstName} ${medicalPersonData.lastName} - ${medicalPersonData.profession}`;
        medicalPersonContact.innerHTML = `${medicalPersonData.address} ${medicalPersonData.postcode} Tel: ${medicalPersonData.telephone}`;
    });
}
getMedicalPersonData();
//# sourceMappingURL=VaccinatePatient.js.map

// Admin birthday 
const d = new Date();
let year = d.getFullYear();
let month = d.getMonth() + 1;

if (month === 12) {
    document.getElementById("AdminYears").innerHTML = year - 2004;
}
else {
    document.getElementById("AdminYears").innerHTML = year - 2005;

}

function forMe() {
    //document.getElementById("v-pills-overview").style.display = "block";
    //document.getElementById("v-pills-mission").style.display = "none";
    //document.getElementById("v-pills-vision").style.display = "none";

    document.getElementById("v-pills-overview-tab").style.background = "linear-gradient(to right, #0172d0, #19a9fe)";
    document.getElementById("h4Txt").style.color = "white";

    document.getElementById("v-pills-mission-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-mission-tab").style.color = "black";

    document.getElementById("v-pills-vision-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-vision-tab").style.color = "black";

    document.getElementById("aboutUs-Info-Title").innerHTML = "Основател:";
    document.getElementById("aboutUs-Info-Text").innerHTML =
        `Аз съм Сечкин, уча в ПГМЕТТ (Професионална гимназия по механотехника, електроника,
                            телекомуникации и транспорт) „Христо Ботев“. Занимавам се с програмиране. На ${year - 2004}
                            години съм.Обичам да преследвам мечтите и целите си.
                            Благодаря на абсолютно всички учители, които ме научиха и най-вече на госпожа Н. Йорданова и
                            господин Н. Христов. `;

}

function forSite() {
    //document.getElementById("v-pills-mission").style.display = "block";
    //document.getElementById("v-pills-overview").style.display = "none";
    //document.getElementById("v-pills-vision").style.display = "none";

    document.getElementById("v-pills-mission-tab").style.background = "linear-gradient(to right, #0172d0, #19a9fe)";
    document.getElementById("v-pills-mission-tab").style.color = "white";

    document.getElementById("v-pills-overview-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-overview-tab").style.color = "black";

    document.getElementById("v-pills-vision-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-vision-tab").style.color = "black";

    document.getElementById("h4Txt").style.color = "black";


    document.getElementById("aboutUs-Info-Title").innerHTML = "Информация за сайта:";
    document.getElementById("aboutUs-Info-Text").innerHTML =
        `Сайтът е програмиран от мен (Сечкин) с езиците HTML, CSS, JavaScript, C# и .Net Core. `;

}


function infoBlock3() {
    document.getElementById("v-pills-vision-tab").style.background = "linear-gradient(to right, #0172d0, #19a9fe)";
    document.getElementById("v-pills-vision-tab").style.color = "white";

    document.getElementById("v-pills-mission-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-mission-tab").style.color = "black";

    document.getElementById("v-pills-overview-tab").style.background = "#f7fbfe";
    document.getElementById("h4Txt").style.color = "black";


    document.getElementById("aboutUs-Info-Title").innerHTML = "ТЕКСТ";
    document.getElementById("aboutUs-Info-Text").innerHTML =
        `ИНФОРМАЦИЯ....`;
}

/*.........Contact Form.............*/
//function ContactsForm()
//{
//    document.getElementById("name").style.borderBottomColor = "blue";
//    document.getElementById("e-mail").style.borderColor = "blue";
//}
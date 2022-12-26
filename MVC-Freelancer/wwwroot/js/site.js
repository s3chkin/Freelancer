function forMe() {
    document.getElementById("v-pills-overview").style.display = "block";
    document.getElementById("v-pills-mission").style.display = "none";
    document.getElementById("v-pills-vision").style.display = "none";

    document.getElementById("v-pills-mission-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-mission-tab").style.color = "black";

    document.getElementById("v-pills-overview-tab").style.background ="linear-gradient(to right, #0172d0, #19a9fe)"; 
    document.getElementById("v-pills-overview-tab").style.color = "white";

}

function forSite() {
    document.getElementById("v-pills-mission").style.display = "block";
    document.getElementById("v-pills-overview").style.display = "none";
    document.getElementById("v-pills-vision").style.display = "none";

    document.getElementById("v-pills-mission-tab").style.background = "linear-gradient(to right, #0172d0, #19a9fe)";
    document.getElementById("v-pills-mission-tab").style.color = "white";

    document.getElementById("v-pills-overview-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-overview-tab").style.color = "black";

}

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

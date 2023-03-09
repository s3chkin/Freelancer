
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
                            телекомуникации и транспорт) „Христо Ботев“. Занимавам се с програмиране. На ${year - 2004 - 1}
                            години съм.Обичам да преследвам мечтите и целите си. Още от първи клас съм изключително старателен ученик.
                            Известен съм с предаването на абсолютно всички домашни на време и се гордея с това. В началото не обичах
                            да уча, може би защото имахме много безсмислени предмети като Човекът и обществото, това е предметът, който ме затрудняваше супер много,
                            става въпрос за втори и трети клас. Една от най-любомите ми години беше 2014 година, когато бях четвърти клас.Където класът,
                            учебните предмети, учителите като цяло когато самото училище ми започна да бъде интересно. Според мен ученик не трябва да се притеснява
                            за другия учебен ден като мен. При мене беше така в пети клас. Никога не забравям, че неделята беше моят кошмар само заради следващия ден,
                            защото имахме „Човекът и природата“ с една супер гадна учителка, която много ни затрудняваше. Друга моя любима учебна година беше през
                            2017/2018 година, когато бях седми клас, а именно и края на основното ми образование. Тогава най-трудното беше раздялата ни с приятелите, с
                            които се познавахме повече от 9 години. Най-трудно ми беше в 8-ми, 9-ти и 10-ти клас. Но тази трудност няма нищо общо с учебните предмети, а
                            с моите нови „приятели“. Точно тогава разбрах, че не съм имал приятели, като почнаха да ме псуват, обиждат и мн. др., само заради, не съм им
                            дал домашните си. Причината да не им давам беше - аз по цял ден се мъчех да ги правя, те си играеха футбол, компютърни игри и други. Но както
                            и да е. Вече не се доверявам на никого лесно. Вече имам други цели и за това продължавам напред, въпреки всички негативни хора, които ми казват,
                            че няма да успея.
                            Благодаря на абсолютно всички учители, които ме научиха и най-вече на госпожа Н. Йорданова и
                            господин Н. Христов.  `;

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
        `Сайтът е програмиран от мен (Сечкин) с езиците HTML, CSS, JavaScript, C# и .Net Core. Моля, ако имате въпроси
свързани със сайта или идеи за поправяне на някои части от сайта, се свържете с мен по g-mail: seckins191@gmail.com
или от менюто отидете на „Контакти“, попълнете формуляра и в полето за съобщение напишете своето мнение!`;

}


function infoBlock3() {
    document.getElementById("v-pills-vision-tab").style.background = "linear-gradient(to right, #0172d0, #19a9fe)";
    document.getElementById("v-pills-vision-tab").style.color = "white";

    document.getElementById("v-pills-mission-tab").style.background = "#f7fbfe";
    document.getElementById("v-pills-mission-tab").style.color = "black";

    document.getElementById("v-pills-overview-tab").style.background = "#f7fbfe";
    document.getElementById("h4Txt").style.color = "black";


    document.getElementById("aboutUs-Info-Title").innerHTML = "Свъжете се с мен";
    document.getElementById("aboutUs-Info-Text").innerHTML =
        `<a href="https://www.facebook.com/seckin.salim"><i class="fa-brands fa-facebook"  style="font-size:60px;  margin-left:30px; margin-top:30px; color:blue;"></i> </a>
<a href="https://www.instagram.com/__sechkin__/"><i class="fa-brands fa-instagram" style="font-size:60px;  margin-left:30px; margin-top:30px; color:pink;"></i></a>
<a href="https://twitter.com/Sekin21044194"><i class="fa-brands fa-twitter"    style="font-size:60px;  margin-left:30px; margin-top:30px; color:lightblue;"></i></a>
<a href="https://github.com/s3chkin"><i class="fa-brands fa-github"     style="font-size:60px;  margin-left:30px; margin-top:30px; color:black;"></i></a>`;
}

/*.........Contact Form.............*/
//function ContactsForm()
//{
//    document.getElementById("name").style.borderBottomColor = "blue";
//    document.getElementById("e-mail").style.borderColor = "blue";
//}

function pause() {

    var x = document.getElementById('visibility');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }

    document.getElementById("trueStatus").innerHTML = "true";

}
function search() { //отказване на поръчки
    Swal.fire({
        title: 'Какво търсите?',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Търси',
        showLoaderOnConfirm: true,
        cancelButtonText: 'Отказ',


        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: `Няма намерени резултати...`,
            })
        }
    })
}
function refuse(idCancelBtn) { //отказване на поръчки
    Swal.fire({
        title: 'Сигурен ли сте?',
        text: "Наистина ли искате да откажете поръчката?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Да, отказвам!',
        cancelButtonText: 'Назад'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Поръчката е отказана!',
                'Можете да разгледате другите обяви.',
                'success',
            );


            //setTimeout(() => {
            //    console.log("Delayed for 1 second.");
            //}, 1000);
            document.getElementById(idCancelBtn).submit()
        }

    })
}
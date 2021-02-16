function Weather(api = "9bcf142db3cf6c641a569f9260fb6c8d") {
    // Top 250 cities in denmark from "https://da.wikipedia.org/wiki/Danmarks_st%C3%B8rste_byer"
    this.cities = ["Aarhus","Odense","Aalborg","Esbjerg","Randers","Kolding","Horsens","Vejle","Roskilde","Herning","Hørsholm","Helsingør","Silkeborg","Næstved","Fredericia","Viborg","Køge","Holstebro","Taastrup","Slagelse","Hillerød","Holbæk","Sønderborg","Svendborg","Hjørring","Frederikshavn","Nørresundby","Ringsted","Ølstykke","Haderslev","Birkerød","Skive","Farum","Smørumnedre","Skanderborg","Nyborg","Lillerød","Nykøbing","Kalundborg","Aabenraa","Solrød","Frederikssund","Ikast","Middelfart","Grenaa","Korsør","Varde","Rønne","Thisted","Værløse","Nakskov","Brønderslev","Frederiksværk","Odder","Dragør","Vordingborg","Hobro","Hedehusene","Haslev","Hedensted","Lystrup","Struer","Jyllinge","Ringkøbing","Vejen","Grindsted","Humlebæk","Nykøbing","Sæby","Hundested","Fredensborg","Galten","Beder","Aars","Ribe","Helsinge","Hadsten","Hørning","Nivå","Skagen","Løgten","Sorø","Skjern","Støvring","Hinnerup","Tønder","Vojens","Bjerringbro","Svenstrup","Brande","Ebeltoft","Bramming","Hammel","Faaborg","Lemvig","Slangerup","Gilleleje","Skælskør","Billund","Assens","Ry","Rødekro","Kerteminde","Ringe","Nordborg","Hirtshals","Aabybro","Maribo","Hornslet","Munkebo","Hellebæk","Børkop","Nibe","Hornbæk","Tune","Nykøbing","Lind","Otterup","Kjellerup","Fensmark","Mårslet","Hadsund","Vamdrup","Bellinge","Strib","Klarup","Rudkøbing","Viby","Borup","Sakskøbing","Give","Brørup","Strøby","Vodskov","Svogerslev","Padborg","Jyderup","Gråsten","Videbæk","Havdrup","Sejs","Jægerspris","Høng","Lynge","Løgstør","Sunds","Kirke","Langeskov","Vildbjerg","Tarm","Faxe","Dianalund","Juelsminde","Solbjerg","Hjallerup","Ølgod","Præstø","Bogense","Årslev","Stege","Tølløse","Harlev","Græsted","Brædstrup","Nexø","Hjortshøj","Løgumkloster","Gistrup","Frederiksberg","Jelling","Assentoft","Fjerritslev","Virklund","Dronninglund","Store","Farsø","Taulov","Storvorde","Glamsbjerg","Toftlund","Broager","Thurø","Aulum","Augustenborg","Søndersø","Vissenbjerg","Skibby","Ejby","Aarup","Vinderup","Holsted","Skærbæk","Lunderskov","Brejning","Bjæverskov","Hvide","Auning","Sindal","Sankt","Skørping","Sabro","Christiansfeld","Asnæs","Rønde","Pandrup","Nørre","Sundby","Vestbjerg","Faxe","Langå","Ganløse","Trige","Oksbøl","Frejlev","Søften","Højslev","Tinglev","Aalestrup","Brovst","Svinninge","Tørring","Ullerslev","Hurup","Tjæreborg","Nordby","Rødding","Høruphav","Kibæk","Skævinge","Hårlev","Gundsømagle","Gram","Liseleje","Stoholm","Vester","Egebjerg","Hals","Nyråd","Kås","Forlev","Starup","Hørve","Arden","Mariager","Guderup"];
    
    // Unique id
    this.id = Math.random().toString(36).substr(2, 9);

    // Fetch information
    this.apiKey = api;
    this.city = null;
    this.url = () => `https://api.openweathermap.org/data/2.5/weather?q=${this.city}&appid=${this.apiKey}&units=metric`;

    // The place to render
    this.selector = null;

    // Fetched data
    this.cityData = [];

    // Clear selector
    this.Clear = () => {
        this.selector.innerHTML = "";
    };

    // Fan Class
    this.f = new Fan();

    // (Re)Renders the application
    this.Render = (selector = null) => {
        // If you change the render location it clears the old location before
        if(this.selector != null)
            this.Clear();
        
        if(selector != null)
            this.selector = document.getElementById(selector);
        
        this.Clear();

        // City Selector
        var sel = document.createElement("select");
        sel.id = "citySelector_" + this.id;
        sel.className += "citySelector";

        // Search Selector
        var input = document.createElement("input");
        input.setAttribute("list", "cityList_" + this.id);
        input.id = "citySearchSelector_" + this.id;
        input.className += "citySearchSelector";

        // Datalist for the search selector
        var list = document.createElement("datalist");
        list.id = "cityList_" + this.id;
     
        // Convert cities array to usable option tags
        this.cities.forEach(elm => {
            var option = document.createElement("option");

            if(this.city != null && this.city.toLowerCase() == elm.toLowerCase())
                option.selected = true;

            option.value = elm;
            option.text = elm;

            sel.appendChild(option);
            list.appendChild(option.cloneNode());
        });

        // Sets the onchange event calls
        sel.onchange = this.ChangeCity;        
        input.onchange = this.ChangeCitySearch;

        // Adds the elements to the selector e.g: body in this case
        this.selector.appendChild(sel);
        this.selector.appendChild(document.createElement("br"));
        this.selector.appendChild(list);
        this.selector.appendChild(input);

        // Get city info
        if(this.city != null)
            this.FetchCity();
    };

    // Onchange event handler for select
    this.ChangeCity = () => {
        this.city = document.getElementById("citySelector_" + this.id).value;
        this.Render();
    };
    
    // Onchange event handler for input search
    this.ChangeCitySearch = () => {
        this.city = document.getElementById("citySearchSelector_" + this.id).value;
        this.Render();
    };

    // Gets city from the weatcher api
    // Also checks if the city is allready in the cityData array
    this.FetchCity = () => {
        if(this.cityData[this.city.toLowerCase()] != null) {
            this.CityInfo();
            return;
        }

        console.log(this.url());
        fetch(this.url())
        .then(response => response.json())
        .then(data => {
            console.log(data);
            this.cityData[this.city.toLowerCase()] = data;
            this.CityInfo();
        });
    };

    // Renders the city info
    this.CityInfo = () => {
        var text = document.createElement("p");

        // Fan settings if it is over 0 degrees
        if(this.cityData[this.city.toLowerCase()].main.temp > 0)
            this.f.setSpeedLow().setLedOn();

        // Fan settings if it is over 10 degrees
        if(this.cityData[this.city.toLowerCase()].main.temp > 10)
            this.f.setSpeedHigh().setLedOn();

        // Fan settings if it is under 0 degrees
        if(this.cityData[this.city.toLowerCase()].main.temp < 0)
            this.f.setSpeedOff().setLedOff();

        // Save information to the micro controller
        // this.f.SendApiCall();

        var info = [
            "City: " + this.cityData[this.city.toLowerCase()].name,
            "Country: " + this.cityData[this.city.toLowerCase()].sys.country,
            "Temp: " + this.cityData[this.city.toLowerCase()].main.temp + "°C",
            "Max Temp: " + this.cityData[this.city.toLowerCase()].main.temp_max + "°C",
            "Min Temp: " + this.cityData[this.city.toLowerCase()].main.temp_min + "°C",
            "Weather: " + this.cityData[this.city.toLowerCase()].weather[0].main,
            "Longitude: " + this.cityData[this.city.toLowerCase()].coord.lon,
            "Latitude: " + this.cityData[this.city.toLowerCase()].coord.lat,
            // "Fan Speed: " + this.f.speed,
            // "Fan Rotate: " + (this.f.rotate == true ? "on" : "off"),
        ];

        text.innerHTML = '<span class="title">' + info.join('<br><span class="title">').replaceAll(':', ':</span>');
        this.selector.appendChild(text);
    };
}

function Fan(domain = "esp.os.ht") {
    this.domain = domain
    this.speed = "off";
    this.rotate = false;
    this.led = false;

    // Speed modes
    this.setSpeedHigh = (send = false) => this.setSpeed("high", send);
    this.setSpeedLow = (send = false) => this.setSpeed("low", send);
    this.setSpeedOff = (send = false) => this.setSpeed("off", send);
    this.setSpeed = (speed, send = false) => {
        this.speed = speed;

        if(send)
            this.SendApiCall();

        return this;
    };

    // Led modes
    this.setLedOn = (send = false) => this.setLed(true, send);
    this.setLedOff = (send = false) => this.setLed(false, send);
    this.setLed = (mode, send = false) => {
        this.led = mode;
        
        if(send)
            this.SendApiCall();
        
        return this;
    };

    // Rotate modes
    this.setRotateOn = (send = false) => this.setRotate(true, send);
    this.setRotateOff = (send = false) => this.setRotate(false, send);
    this.setRotate = (mode, send = false) => {
        this.rotate = mode;
        
        if(send)
            this.SendApiCall();

        return this;
    };

    // Sends the data to the micro controller
    this.SendApiCall = () => {
        fetch("http://" + this.domain + "/?power=" + this.speed + "&rotate=" + (this.rotate == true ? "on" : "off") + "&led=" + (this.led == true ? "on" : "off"), { mode: 'no-cors'});
    };

}

// When the page is loaded render the application
window.addEventListener('load', function () {
    // Weather class
    w1 = new Weather();
    w2 = new Weather();

    // Render function and where to render the weather application
    w1.Render("w1");
    w2.Render("w2");
});
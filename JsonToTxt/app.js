const fs = require('fs');

fs.readFile("countries.json", (err, data) => {
    let obj = JSON.parse(data.toString());
    let keys = Object.keys(obj);
    let str = "";
    for (let i = 0; i < keys.length; i++) {
        let country = obj[keys[i]];
        let continent = "";
        switch (country.continent) {
            case "AS":
                continent = "Asia";
                break;
            case "EU":
                continent = "Europe";
                break;
            case "NA":
                continent = "NorthAmerica";
                break;
            case "SA":
                continent = "SouthAmerica";
                break;
            case "AF":
                continent = "Africa";
                break;
            case "OC":
                continent = "Oceania";
                break;
        }
        str += keys[i] + ";" + country.name + ";" + continent + "\n";
    }
    fs.writeFile("countries.txt", str, () => { });
});
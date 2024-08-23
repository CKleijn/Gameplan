import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import resourcesEN from "./resources-en.json";
import resourcesNL from "./resources-nl.json";

const resources = {
    en: resourcesEN,
    nl: resourcesNL,
};

i18n
    .use(initReactI18next)
    .init({
        resources,
        lng: localStorage.getItem("lng") || navigator.language,
        fallbackLng: "en",
        supportedLngs: ["en", "nl"],
        interpolation: {
            escapeValue: false,
        }
    });

export default i18n;
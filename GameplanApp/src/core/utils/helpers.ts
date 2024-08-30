import { useTranslation } from "react-i18next";
import { useSelector } from "react-redux";
import { RootState } from "../services/redux/store";

export const getEnumKeyByValue = (enumObj: any, value: string) => Object.keys(enumObj).find(key => enumObj[key] === value);
export const dateFormatter = (date: string) => {
    const { i18n } = useTranslation();

    const formatter = new Intl.DateTimeFormat(i18n.language, {
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
    });

    return formatter.format(new Date(date));
};
export const isCreator = (creatorUID: string) => {
    const user = useSelector((state: RootState) => state.userSlice.user);
    return user?.uid == creatorUID;
}
export const objToQueryParamsString = (obj: any) => {
    const keyValuePairs = [];
    for (const key in obj) {
        if (obj[key] !== null) {
            keyValuePairs.push(encodeURIComponent(key) + '=' + encodeURIComponent(obj[key]));
        }
    }
    return keyValuePairs.join('&');
}
import { useTranslation } from "react-i18next";

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
}
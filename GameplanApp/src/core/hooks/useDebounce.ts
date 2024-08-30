import { useState, useEffect } from "react";

const useDebounce = (value: any) => {
    const [debounceValue, setDebounceValue] = useState(value);

    useEffect(() => {
        const handler = setTimeout(() => {
            setDebounceValue(value);
        }, 300);

        return () => {
            clearTimeout(handler);
        };
    }, [value]);

    return debounceValue;
}

export default useDebounce;
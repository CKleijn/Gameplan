import { getAuth } from "firebase/auth";

type RequestProps = {
    endpoint: string;
    method: 'GET' | 'POST' | 'PUT' | 'DELETE';
    body?: any;
    signal?: AbortSignal;
};

const createRequest = async ({ endpoint, method, body, signal }: RequestProps) => {
    const auth = getAuth();
    const token = await auth.currentUser?.getIdToken();

    const options: RequestInit = {
        method,
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        signal
    }

    if (body) {
        options.body = JSON.stringify(body);
    }

    const response = await fetch(`${import.meta.env.VITE_API_BASE_URL}${endpoint}`, options);

    if (!response.ok) {
        console.log(`Fetch API error: (${method}) - ${endpoint}`);
    }

    if (method == 'GET') {
        return await response.json();
    }
}

export default createRequest;
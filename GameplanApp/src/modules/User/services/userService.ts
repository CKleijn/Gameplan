import createRequest from "@/core/utils/httpClient";
import { User } from "../User";

export const getUserByUID = async (uid: string) => await createRequest({ endpoint: `user/${uid}`, method: 'GET' });
export const registerUser = async (user: User) => await createRequest({ endpoint: 'user/register', method: 'POST', body: user });
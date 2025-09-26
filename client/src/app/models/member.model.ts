import { Photo } from "./photo.model";

export interface Member {
    email: string;
    userName: string;
    age: number;
    city: string;
    country: string;
    photos: Photo[];
}
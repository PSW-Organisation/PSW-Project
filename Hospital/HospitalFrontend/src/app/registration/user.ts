import { Allergen } from "./allergen";

export interface User{
    username: string,
    password: string,
    name: string,
    parentName: string,
    surname: string,
    dateOfBirth: Date,
    gender: string,
    phone: string,
    email: string,
    address: string,
    city: string,
    country: string,
    personalId: string,
    bloodType: string,
    profession: string,
    doctor: string,
    height: number,
    weight: number,
    allergens: Allergen[]
}
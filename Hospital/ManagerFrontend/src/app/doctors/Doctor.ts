export class Doctor {
    id: string;
    specialization: string;
    roomId: number;
    username: string;
    name: string;
    surname: string;
    phone: string;
    email: string;
    address: string;
    city: string;
    country: string;
    shiftOrder: number;

    constructor(id: string,
        specialization: string,
        roomId: number,
        username: string,
        name: string,
        surname: string,
        phone: string,
        email: string,
        address: string,
        city: string,
        country: string,
        shiftOrder: number) {
        
        this.id = id;
        this.specialization = specialization;
        this.roomId = roomId;
        this.username = username;
        this.name = name;
        this.surname = surname;
        this.phone = phone;
        this.email = email;
        this.address = address;
        this.city = city;
        this.country = country;
        this.shiftOrder = shiftOrder;

    }



}
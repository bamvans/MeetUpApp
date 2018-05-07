import { Component } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { Injectable } from '@angular/core'  
import 'rxjs/add/operator/map';  

@Injectable()
export class AuthService {

    constructor(private http: Http, private router: Router, private sanitizer: DomSanitizer) {
    }

    //get for users
    public getUser() {
        return this.http.get("http://localhost:60440/api/login")
            .map((response: Response) => <User[]>response.json());
    }

    getById(_id: string) {
        return this.http.get("http://localhost:60440/api/login" + _id)
            .map((response: Response) => response.json());
    }

    getbyEmail(email: string) {
        return this.http.get("http://localhost:60440/api/login" , email)
            .map((response: Response) => response.json());
    }

    create(user: User) {
        return this.http.post("http://localhost:60440/api/login", user);
    }

    update(user: User) {
        return this.http.put("http://localhost:60440/api/login" + user.id, user);
    }

    delete(_id: string) {
        return this.http.delete("http://localhost:60440/api/login" + _id);
    }
   
}

export interface User {
    id: string;
    email: string;
    pass: string;
}

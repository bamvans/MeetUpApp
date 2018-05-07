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

    public getById(id: string) {
        return this.http.get("http://localhost:60440/api/login" + id)
            .map((response: Response) => response.json());
    }

    public getbyEmail(email: string) {
        return this.http.get("http://localhost:60440/api/login" , email)
            .map((response: Response) => response.json());
    }

    public create(user: User) {
        return this.http.post("http://localhost:60440/api/login/create", user);
    }

    public update(user: User) {
        return this.http.put("http://localhost:60440/api/login" + user.id, user);
    }

    public delete(id: string) {
        return this.http.delete("http://localhost:60440/api/login" + id);
    }
   
}

export interface User {
    id: string;
    email: string;
    pass: string;
}

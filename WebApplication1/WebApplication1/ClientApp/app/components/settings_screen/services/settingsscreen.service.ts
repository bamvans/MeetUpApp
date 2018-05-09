import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { Injectable } from '@angular/core'  
import 'rxjs/add/operator/map';  

@Injectable()
export class SettingsScreenService {

    constructor(private http: Http, private router: Router, private sanitizer: DomSanitizer) {
    }

    //get for categories
    public getCategories() {
        return this.http.get("http://localhost:60440/api/category")
            .map((response: Response) => <Category[]>response.json());  
    }

    //get for cities
    public getCities() {
        return this.http.get("http://localhost:60440/api/city")
            .map((response: Response) => <City[]>response.json());
    }

    //create for Categories
    public createCategories(cc: Category) {
        return this.http.post("http://localhost:60440/api/category/create", cc)
            .map(x => <Category>x.json());
    }

    //create for Cities
    public createCities(ci: City) {
        return this.http.post("http://localhost:60440/api/city/create", ci)
            .map(x => <City>x.json());
    }

    //get category by id
    public getByIdCategories(id: string) {
        return this.http.get("http://localhost:60440/api/category" + id)
            .map((response: Response) => response.json());
    }

    //get city by id
    public getByIdCities(id: string) {
        return this.http.get("http://localhost:60440/city" + id)
            .map((response: Response) => response.json());
    }
}

export interface Category {
    id: number;
    name: string;
    description: string;
}

export interface City {
    id: number;
    name: string;
}

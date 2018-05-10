import { Component } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { User, AuthService } from '../services/auth.service';

@Component({
    templateUrl: './auth.component.html',
    styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit{

    author: User[];

    constructor(private http: Http, private router: Router, private sanitizer: DomSanitizer, protected authService: AuthService) {

    }

    ngOnInit() {
        this.authService.getUser().subscribe(result => this.author = result);
    }

    login(username: string, password: string) {
        var data = new URLSearchParams();
        data.append('grant_type', 'password');
        data.append('username', username);
        data.append('password', password);
        return this.http.post("http://localhost:60440/token", data)
            .map(response => {
                var result = response.json();
                return result.access_token;
            });
    }
}

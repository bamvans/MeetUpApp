import { NgModule, Inject } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AuthComponent } from './components/auth.component';
import { AuthService } from './services/auth.service';



@NgModule({
    declarations: [
        AuthComponent
    ],
    providers: [
        AuthService
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,

        RouterModule.forRoot([
            { path: 'auth', component: AuthComponent },
            { path: '', redirectTo: 'auth', pathMatch: 'full' }
        ])
    ]
})

export class AuthModule {
}

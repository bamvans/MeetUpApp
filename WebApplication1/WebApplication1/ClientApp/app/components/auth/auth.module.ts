import { NgModule, Inject } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AuthComponent } from './components/auth.component';
import { AuthService } from './services/auth.service';
import { PasswordModule } from 'primeng/password';
import { PanelModule } from 'primeng/panel';


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
        PasswordModule,
        PanelModule,
        RouterModule.forRoot([
            { path: 'auth', component: AuthComponent },
            { path: '', redirectTo: 'auth', pathMatch: 'full' }
        ])
    ]
})

export class AuthModule {
}

import {Component} from '@angular/core'
import { FormControl } from '@angular/forms';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class Login{
    name = new FormControl('');
    pass = new FormControl('');
    
}
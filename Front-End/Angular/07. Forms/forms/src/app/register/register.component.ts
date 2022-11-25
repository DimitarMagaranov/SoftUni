import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, NgForm, ValidatorFn, Validators } from '@angular/forms';

const myCustomValidator: ValidatorFn = (control: AbstractControl) => {
  return control.value.length > 10 ? { myCustomValidator: 'The pass is longer than the maximum symbols of 10' } : null;
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.minLength(5), Validators.required, myCustomValidator]]
  })

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  handleFormSubmit(form: any): void {
    if (form.invalid) { return; }
    const value: {email: string, password: string} = form.value;
    console.log(value);
    form.setValue({email:'', password:''});
  }
}

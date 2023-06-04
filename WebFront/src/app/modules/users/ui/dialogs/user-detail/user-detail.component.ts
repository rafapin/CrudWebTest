import { Component, Inject, inject } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IUserRepository } from '@users/application';
import { User } from '@users/domain';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent {
  userForm!: FormGroup;
  userRepository = inject(IUserRepository)
  isInternalUpdate:Boolean = false
  constructor(private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<UserDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public user: User
    ) { }

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.userForm = this.formBuilder.group({
      userName: ['', [Validators.required,Validators.minLength(5), Validators.maxLength(30)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['']
    });
    if(this.user)
      this.userForm.patchValue({...this.user});
    
    this.setPasswordValidator()?.subscribe(value=>{
      console.log(value)
      if(!this.isInternalUpdate){
        this.setPasswordValidator()
      }
      this.isInternalUpdate = false
    })
  }

  setPasswordValidator():Observable<any>|undefined{
      const passwordControl = this.userForm.get('password');
      if (!this.user || !this.user.id || passwordControl?.value.length > 0) {
        passwordControl?.setValidators([
          Validators.required,
          Validators.minLength(5),
          Validators.pattern(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).*$/)
        ]);        
      }  
      else if(passwordControl?.value.length <= 0)
        passwordControl?.setValidators([])
      
      this.isInternalUpdate = true
      passwordControl?.updateValueAndValidity();
      return passwordControl?.valueChanges;
  }

  onSubmit() {
    if (this.userForm.valid) {
      const userData: User = this.userForm.value;
      if(this.user.id){        
        userData.id = this.user.id
        this.userRepository.Update(userData).then(response=>{
          this.dialogRef.close();
        })
      }
      else{
        this.userRepository.Add(userData).then(response=>{
          this.dialogRef.close();
        })
      }
    }
  }

  onCancel() {
    this.dialogRef.close();
  }

  passwordChange(){
    
  }
}

import { RegisterService } from './../Service/register.service';
import { Register } from './../Models/register';
import { Component, Inject, OnInit, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { identifierModuleUrl } from '@angular/compiler';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup;
  public registerselected: Register;
  public Text: string;
  public PostOrPut


 public  registers: Register[];
// {id:0,Name: 'adriano',Email: 'adriano@hotmail.com',Phone: '11-111111-1111',Linkedin:'www.Linkedin.com.br',LinkCRUD:'www.LinkCRUD.com.br',City:'SP',State:'sao paulo',Portfolio:'www.Portfolio.com.br',salaryPrefer:'2000',RegisterId:1,willingnessWorkWeek:'Acima de 8 horas por dia)',TimeWork:'08:00 ás 12:00',Knowledge:'Android,3',OtherLanguageFramework:'xamarin,3'},
// {id:1,Name: 'testenome',Email: 'teste@hotmail.com',Phone: '11-111111-1111',Linkedin:'www.Linkedin.com.br',LinkCRUD:'www.LinkCRUD.com.br',City:'SP',State:'saopaulo',Portfolio:'www.Portfolio.com.br',salaryPrefer:'2000', RegisterId:2,willingnessWorkWeek:'Acima de 8 horas por dia)',TimeWork:'08:00 ás 12:00',Knowledge:'Ionic,3',OtherLanguageFramework:'javascript,3'},
// {id:2,Name: 'outronome',Email: 'outronome@hotmail.com',Phone: '11-111111-1111',Linkedin:'www.Linkedin.com.br',LinkCRUD:'www.LinkCRUD.com.br',City:'SP',State:'saopaulo',Portfolio:'www.Portfolio.com.br',salaryPrefer:'2000', RegisterId:3,willingnessWorkWeek:'Acima de 8 horas por dia)',TimeWork:'08:00 ás 12:00',Knowledge:'Angular 6,3',OtherLanguageFramework:'ReactJS,5,xamarin,3'},
// {id:3,Name: 'pricila',Email: 'pricila@hotmail.com',Phone: '11-111111-1111',Linkedin:'www.Linkedin.com.br',LinkCRUD:'www.LinkCRUD.com.br',City:'SP',State:'saopaulo',Portfolio:'www.Portfolio.com.br',salaryPrefer:'2000', RegisterId:4,willingnessWorkWeek:'Acima de 8 horas por dia)',TimeWork:'08:00 ás 12:00',Knowledge:'Flutter,3',OtherLanguageFramework:'go,5,ef core,3'},
// {id:4,Name: 'katia',Email: 'katia@hotmail.com',Phone: '11-111111-1111',Linkedin:'www.Linkedin.com.br',LinkCRUD:'www.LinkCRUD.com.br',City:'SP',State:'saopaulo',Portfolio:'www.Portfolio.com.br',salaryPrefer:'2000',RegisterId:5,willingnessWorkWeek:'Acima de 8 horas por dia)',TimeWork:'08:00 ás 12:00',Knowledge:'C++,3',OtherLanguageFramework:'SWIFT,5,angular,3,css,1,go,5'},
// ];




constructor(private fb: FormBuilder, private registerService: RegisterService ) {
  this.createForm();
}

ngOnInit(){
  this.loadRegisters();
}

loadRegisters()
{
  this.registerService.getAll().subscribe(
    (registers: Register[]) => {this.registers = registers}, error => console.error(error));

}

createForm()
{
  this.registerForm = this.fb.group({
    id:['', Validators.required],
    name: ['', Validators.required],
    email: ['', Validators.required],
    phone: ['', Validators.required],
    linkedin: [''],
    linkCRUD: [''],
    city: ['', Validators.required],
    state: ['', Validators.required],
    portfolio: ['', Validators.required],
    salaryPrefer: [''],
    willingnessWorkWeek: [''],
    timeWork: [''],
    knowledge: [''],
    otherLanguageFramework: ['']
  });
}

updateRegister(register: Register)
{
  if (register.id === 0)
  {
    this.PostOrPut = 'post'

  }
  else
  {
    this.PostOrPut = 'put'
  }

  //atualizar registro / novo registro
  this.registerService[this.PostOrPut](register).subscribe(
    (back: Register) => {console.log(back);this.loadRegisters();}, error => console.error(error));

}

deleteRegister(id: number)
{
  //deletar o registro
  this.registerService.delete(id).subscribe(
    (back: Register) => {console.log(back);this.loadRegisters();}, error => console.error(error));

}
registerSubmit()
{
  this.updateRegister(this.registerForm.value);
}

selectedRegister(register: Register)
{
  this.registerselected = register;
  this.registerForm.patchValue(register);
}

newRegister()
{
  this.registerselected = new Register();
  this.registerForm.patchValue(this.registerselected);
}

comeback()
{
  this.registerselected = null;
}


}


import { InvitedUserDTO } from './../proxy/invited-users/models';
import { InvitedUserAppServicesService } from './../proxy/invited-users/invited-user-app-services.service';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invited-users',
  templateUrl: './invited-users.component.html',
  providers: [ListService],
  styleUrls: ['./invited-users.component.scss']
})
export class InvitedUsersComponent implements OnInit{
  
  // constructor(public list: ListService, private appService: InvitedUserAppServicesService) {}
  constructor(public list: ListService, private appService: InvitedUserAppServicesService, private fb: FormBuilder) {}

  users = {items: [], totalCount: 0} as PagedResultDto<InvitedUserDTO> 
  isModalOpen = false
  form: FormGroup
  selectedUser: any 

  ngOnInit(): void {
    this.getList()
  }

  getList(){
    const userStreamCreator = query => this.appService.getList(query);
    this.list.hookToQuery(userStreamCreator).subscribe(res => { this.users = res })
  }

  inviteUser(){
    this.selectedUser = {}
    this.buildForm()
    this.isModalOpen = true
  }

  buildForm(){
    this.form = this.fb.group({
      firstName: [this.selectedUser ? this.selectedUser.firstName: '', Validators.required],
      lastName: [this.selectedUser? this.selectedUser.lastName: '', Validators.required],
      email: [this.selectedUser ? this.selectedUser.email: '', Validators.email],
      phoneNumber: [this.selectedUser? this.selectedUser.phoneNumber: '', Validators.required]
    })
  }

  editUser(id){
    this.appService.get(id).subscribe(res => {
      this.selectedUser = res
      this.buildForm()
      this.isModalOpen = true
    })
  }

  deleteUser(id){
    this.appService.delete(id).subscribe(res => {
      this.getList()
    })
  }

  save(){}
}

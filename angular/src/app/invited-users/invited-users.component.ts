import { InvitedUserDTO } from './../proxy/invited-users/models';
import { InvitedUserAppServicesService } from './../proxy/invited-users/invited-user-app-services.service';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invited-users',
  templateUrl: './invited-users.component.html',
  providers: [ListService],
  styleUrls: ['./invited-users.component.scss']
})
export class InvitedUsersComponent implements OnInit{
  
  // constructor(public list: ListService, private appService: InvitedUserAppServicesService) {}
  constructor(public list: ListService, private appService: InvitedUserAppServicesService) {}

  users = {items: [], totalCount: 0} as PagedResultDto<InvitedUserDTO> 
  isModalOpen = false

  ngOnInit(): void {
    this.getList()
  }

  getList()
  {
    const userStreamCreator = query => this.appService.getList(query);
    this.list.hookToQuery(userStreamCreator).subscribe(res => {
      this.users = res
      console.log(this.users);
    })
  }

  editUser(id){}

  deleteUser(id){}
}

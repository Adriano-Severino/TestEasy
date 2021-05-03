import { Skill } from "./register-skills";

export class Register {
  id: number;
  name: string;
  email: string;
  phone: string;
  linkedin: string;
  linkCRUD: string;
  city: string;
  state: string;
  portfolio: string;
  salaryPrefer: string;
  createDateTime: Date;
  skills: Skill[];
}




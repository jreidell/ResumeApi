import { JobSkill } from './JobSkill';
import { WorkHistory } from './WorkHistory';

export class CareerInfo {
    CareerInfoId: string;
    FirstName: string;
    MiddleName: string;
    LastName: string;
    Suffix: string;
    EmailAddress: string;
    Address1: string;
    Address2: string;
    City: string;
    State: string;
    PostalCode: string;
    Phone: string;
    Mobile: string;
    CareerInfoTitle: string;
    Summary: string;
    Enabled: boolean;
    JobSkills: JobSkill[];
    WorkHistory: WorkHistory[];
}

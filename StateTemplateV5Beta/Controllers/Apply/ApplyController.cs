using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Apply
{
    [RoutePrefix("Apply")]
    public class ApplyController : Controller
    {
        // GET: Apply
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            ApplyModel viewModel = new ApplyModel();
            List<String> JobsList = new List<String>();
            List<String> AgencyList = new List<String>();

            JobsList.Add("General Public");
            JobsList.Add("California State Employee");
            JobsList.Add("State Legislative Staff");
            JobsList.Add("Appointed State Official/Board Members");
            JobsList.Add("Faculty or Staff at UC/CSU");
            JobsList.Add("Officials/Employees of State Court");

            AgencyList.Add("**I can't find my agency");
            AgencyList.Add("Administrative Law, Office of");
            AgencyList.Add("Aging, California Commission on");
            AgencyList.Add("Aging, Department of");
            AgencyList.Add("Agricultural Labor Relations Board");
            AgencyList.Add("Air Resources Board");
            AgencyList.Add("Alcohol and Drug Programs, Department of");
            AgencyList.Add("Alcoholic Beverage Control Appeals Board");
            AgencyList.Add("Alcoholic Beverage Control, Department of");
            AgencyList.Add("Arts Council");
            AgencyList.Add("Assembly, California State");
            AgencyList.Add("Audits, Bureau of State");
            AgencyList.Add("Baldwin Hills Conservancy");
            AgencyList.Add("Bar of California, State");
            AgencyList.Add("Boating and Waterways, California Department of");
            AgencyList.Add("Business and Economic Development, Governor&#39;s Office of");
            AgencyList.Add("Business Oversight, Department of");
            AgencyList.Add("California State Transportation Agency");
            AgencyList.Add("California State University");
            AgencyList.Add("California Volunteers");
            AgencyList.Add("Central Valley Flood Protection Board");
            AgencyList.Add("Child Support Services, Department of");
            AgencyList.Add("Children &amp; Families Commission, California");
            AgencyList.Add("Chiropractic Examiners, Board of");
            AgencyList.Add("Citizens Redistricting Commission");
            AgencyList.Add("Coachella Valley Mountains Conservancy");
            AgencyList.Add("Coastal Commission, California");
            AgencyList.Add("Coastal Conservancy, State");
            AgencyList.Add("Colorado River Board of California");
            AgencyList.Add("Community Colleges Chancellor&#39;s Office, California ");
            AgencyList.Add("Community Services and Development, Department of");
            AgencyList.Add("Compensation Insurance Fund, State");
            AgencyList.Add("Conservation Corps, California");
            AgencyList.Add("Conservation, Department of");
            AgencyList.Add("Consumer Affairs, Department of");
            AgencyList.Add("Controller&#39;s Office, California State");
            AgencyList.Add("Corrections and Rehabilitation, Department of");
            AgencyList.Add("Courts, California");
            AgencyList.Add("Delta Conservancy");
            AgencyList.Add("Delta Protection Commission");
            AgencyList.Add("Delta Stewardship Council");
            AgencyList.Add("Developmental Disabilities, State Council on");
            AgencyList.Add("Developmental Services, Department of");
            AgencyList.Add("Earthquake Authority, California");
            AgencyList.Add("Education, Department of");
            AgencyList.Add("Emergency Management Agency, California");
            AgencyList.Add("Emergency Medical Services Authority");
            AgencyList.Add("Employment Development Department");
            AgencyList.Add("Employment Training Panel");
            AgencyList.Add("Energy Commission, California");
            AgencyList.Add("Environment Resources Evaluation System, California");
            AgencyList.Add("Environmental Health Hazard Assessment, Office of");
            AgencyList.Add("Environmental Protection Agency");
            AgencyList.Add("Equalization, Board of");
            AgencyList.Add("eServices Office");
            AgencyList.Add("Exposition and State Fair, California");
            AgencyList.Add("Fair Employment and Housing, Department of");
            AgencyList.Add("Fair Political Practices Commission");
            AgencyList.Add("Film Commission, California");
            AgencyList.Add("Finance, Department of");
            AgencyList.Add("Financial Information System for California");
            AgencyList.Add("Fish and Game Commission");
            AgencyList.Add("Fish and Wildlife, Department of");
            AgencyList.Add("Food and Agriculture, Department of");
            AgencyList.Add("Forestry and Fire Protection, California Department of");
            AgencyList.Add("Franchise Tax Board");
            AgencyList.Add("Gambling Control Commission");
            AgencyList.Add("General Services, Department of");
            AgencyList.Add("Governor&#39;s Office of Planning and Research");
            AgencyList.Add("Governor, Office of the");
            AgencyList.Add("Habeas Corpus Resource Center");
            AgencyList.Add("Health and Human Services Agency");
            AgencyList.Add("Health Benefit Exchange, California");
            AgencyList.Add("Health Care Services, Department of");
            AgencyList.Add("Health Information Integrity, California Office of");
            AgencyList.Add("High-Speed Rail Authority");
            AgencyList.Add("Highway Patrol, California");
            AgencyList.Add("Horse Racing Board, California");
            AgencyList.Add("Housing and Community Development, Department of");
            AgencyList.Add("Housing Finance Agency");
            AgencyList.Add("Human Resources, Department of");
            AgencyList.Add("Independent Living Council, California State");
            AgencyList.Add("Industrial Relations, Department of");
            AgencyList.Add("Infrastructure and Economic Development Bank");
            AgencyList.Add("Inspector General, Office of the");
            AgencyList.Add("Insurance, Department of");
            AgencyList.Add("Justice, Department of");
            AgencyList.Add("Labor and Workforce Development Agency");
            AgencyList.Add("Lands Commission, California State");
            AgencyList.Add("Law Revision Committee");
            AgencyList.Add("Legislative Analyst&#39;s Office");
            AgencyList.Add("Legislative Counsel, Office of");
            AgencyList.Add("Legislature, California State");
            AgencyList.Add("Library, California State");
            AgencyList.Add("Lieutenant Governor, Office of");
            AgencyList.Add("Little Hoover Commission");
            AgencyList.Add("Lottery, State");
            AgencyList.Add("Managed Health Care, Department of");
            AgencyList.Add("Managed Risk Medical Insurance Board");
            AgencyList.Add("Medical Board of California");
            AgencyList.Add("Mental Health Services Oversight and Accountability Commission");
            AgencyList.Add("Military Department");
            AgencyList.Add("Military Museum, California State");
            AgencyList.Add("Motor Vehicles, Department of");
            AgencyList.Add("Museum, the California");
            AgencyList.Add("Natural Resources Agency");
            AgencyList.Add("New Motor Vehicle Board");
            AgencyList.Add("Parks and Recreation, Department of");
            AgencyList.Add("Patient Advocate, Office of the");
            AgencyList.Add("Peace Officer Standards and Training, Commission on");
            AgencyList.Add("Personnel Board, State");
            AgencyList.Add("Pesticide Regulation, Department of");
            AgencyList.Add("Pilot Commissioners, Board of");
            AgencyList.Add("Prison Industry Authority");
            AgencyList.Add("Public Defender, Office of the State");
            AgencyList.Add("Public Employees Retirement System, California");
            AgencyList.Add("Public Employment Relations Board, California");
            AgencyList.Add("Public Health, California Department of");
            AgencyList.Add("Public Utilities Commission, California");
            AgencyList.Add("Real Estate, Department of");
            AgencyList.Add("Regenerative Medicine, California Institute for");
            AgencyList.Add("Rehabilitation, Department of");
            AgencyList.Add("Resources Recycling and Recovery, Department of");
            AgencyList.Add("San Diego River Conservancy");
            AgencyList.Add("San Francisco Bay Conservation and Development Commission");
            AgencyList.Add("San Francisco Estuary Institute");
            AgencyList.Add("San Gabriel and Lower Los Angeles Rivers and Mountains Conservancy");
            AgencyList.Add("San Joaquin River Conservancy");
            AgencyList.Add("Santa Monica Mountains Conservancy");
            AgencyList.Add("Secretary of State");
            AgencyList.Add("Seismic Safety Commission");
            AgencyList.Add("Senate, California State");
            AgencyList.Add("Sierra Nevada Conservancy");
            AgencyList.Add("Small Business Development Centers");
            AgencyList.Add("Social Services, Department of");
            AgencyList.Add("State and Consumer Services Agency");
            AgencyList.Add("State Hospitals, Department of");
            AgencyList.Add("State Mandates, Commission on");
            AgencyList.Add("Statewide Health Planning and Development,  Office of");
            AgencyList.Add("Status of Women, Commission on");
            AgencyList.Add("Student Aid Commission");
            AgencyList.Add("Summer School for the Arts, California State");
            AgencyList.Add("Systems Integration, Office of");
            AgencyList.Add("Tahoe Conservancy, California");
            AgencyList.Add("Teacher Credentialing, Commission on");
            AgencyList.Add("Teachers&#39; Retirement System, California");
            AgencyList.Add("Technology Agency, California");
            AgencyList.Add("Toxic Substances Control, Department of");
            AgencyList.Add("Traffic Safety, Office of");
            AgencyList.Add("Transportation, Department of");
            AgencyList.Add("Travel and Tourism Commission, California");
            AgencyList.Add("Treasurer&#39;s Office, State");
            AgencyList.Add("Unemployment Insurance Appeals Board");
            AgencyList.Add("University of California");
            AgencyList.Add("Veterans Affairs, Department of");
            AgencyList.Add("Victim Compensation and Government Claims Board");
            AgencyList.Add("Water Resources Control Board");
            AgencyList.Add("Water Resources, Department of");
            AgencyList.Add("Wildlife Conservation Board");
            viewModel.Jobs = JobsList;
            viewModel.Agency = AgencyList;

            return View("Apply", viewModel);
        }

        // GET: Apply
        [HttpPost]
        [Route("")]
        public ActionResult Index(ApplyModel viewModel)
        {
            //put code here to handle what happens after form is submitted
            //
            //code below will redirect to email error page if return type of service method is false, see exams handling in the exam controllers
            //if (success == false)
            //{
            //    return RedirectToAction("EmailError", "error");
            //}
            return View("Apply", viewModel);
        }
    }
}
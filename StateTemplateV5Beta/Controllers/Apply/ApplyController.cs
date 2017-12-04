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
            viewModel.Jobs.Add("California State Employee");
            viewModel.Jobs.Add("State Legislative Staff");
            viewModel.Jobs.Add("Appointed State Official/Board Members");
            viewModel.Jobs.Add("Faculty or Staff at UC/CSU");
            viewModel.Jobs.Add("Officials/Employees of State Court");
            viewModel.Jobs.Add("General Public");
            viewModel.Agency.Add("** I can&#39;t find my agency");
            viewModel.Agency.Add("Administrative Law, Office of");
            viewModel.Agency.Add("Aging, California Commission on");
            viewModel.Agency.Add("Aging, Department of");
            viewModel.Agency.Add("Agricultural Labor Relations Board");
            viewModel.Agency.Add("Air Resources Board");
            viewModel.Agency.Add("Alcohol and Drug Programs, Department of");
            viewModel.Agency.Add("Alcoholic Beverage Control Appeals Board");
            viewModel.Agency.Add("Alcoholic Beverage Control, Department of");
            viewModel.Agency.Add("Arts Council");
            viewModel.Agency.Add("Assembly, California State");
            viewModel.Agency.Add("Audits, Bureau of State");
            viewModel.Agency.Add("Baldwin Hills Conservancy");
            viewModel.Agency.Add("Bar of California, State");
            viewModel.Agency.Add("Boating and Waterways, California Department of");
            viewModel.Agency.Add("Business and Economic Development, Governor&#39;s Office of");
            viewModel.Agency.Add("Business Oversight, Department of");
            viewModel.Agency.Add("California State Transportation Agency");
            viewModel.Agency.Add("California State University");
            viewModel.Agency.Add("California Volunteers");
            viewModel.Agency.Add("Central Valley Flood Protection Board");
            viewModel.Agency.Add("Child Support Services, Department of");
            viewModel.Agency.Add("Children &amp; Families Commission, California");
            viewModel.Agency.Add("Chiropractic Examiners, Board of");
            viewModel.Agency.Add("Citizens Redistricting Commission");
            viewModel.Agency.Add("Coachella Valley Mountains Conservancy");
            viewModel.Agency.Add("Coastal Commission, California");
            viewModel.Agency.Add("Coastal Conservancy, State");
            viewModel.Agency.Add("Colorado River Board of California");
            viewModel.Agency.Add("Community Colleges Chancellor&#39;s Office, California ");
            viewModel.Agency.Add("Community Services and Development, Department of");
            viewModel.Agency.Add("Compensation Insurance Fund, State");
            viewModel.Agency.Add("Conservation Corps, California");
            viewModel.Agency.Add("Conservation, Department of");
            viewModel.Agency.Add("Consumer Affairs, Department of");
            viewModel.Agency.Add("Controller&#39;s Office, California State");
            viewModel.Agency.Add("Corrections and Rehabilitation, Department of");
            viewModel.Agency.Add("Courts, California");
            viewModel.Agency.Add("Delta Conservancy");
            viewModel.Agency.Add("Delta Protection Commission");
            viewModel.Agency.Add("Delta Stewardship Council");
            viewModel.Agency.Add("Developmental Disabilities, State Council on");
            viewModel.Agency.Add("Developmental Services, Department of");
            viewModel.Agency.Add("Earthquake Authority, California");
            viewModel.Agency.Add("Education, Department of");
            viewModel.Agency.Add("Emergency Management Agency, California");
            viewModel.Agency.Add("Emergency Medical Services Authority");
            viewModel.Agency.Add("Employment Development Department");
            viewModel.Agency.Add("Employment Training Panel");
            viewModel.Agency.Add("Energy Commission, California");
            viewModel.Agency.Add("Environment Resources Evaluation System, California");
            viewModel.Agency.Add("Environmental Health Hazard Assessment, Office of");
            viewModel.Agency.Add("Environmental Protection Agency");
            viewModel.Agency.Add("Equalization, Board of");
            viewModel.Agency.Add("eServices Office");
            viewModel.Agency.Add("Exposition and State Fair, California");
            viewModel.Agency.Add("Fair Employment and Housing, Department of");
            viewModel.Agency.Add("Fair Political Practices Commission");
            viewModel.Agency.Add("Film Commission, California");
            viewModel.Agency.Add("Finance, Department of");
            viewModel.Agency.Add("Financial Information System for California");
            viewModel.Agency.Add("Fish and Game Commission");
            viewModel.Agency.Add("Fish and Wildlife, Department of");
            viewModel.Agency.Add("Food and Agriculture, Department of");
            viewModel.Agency.Add("Forestry and Fire Protection, California Department of");
            viewModel.Agency.Add("Franchise Tax Board");
            viewModel.Agency.Add("Gambling Control Commission");
            viewModel.Agency.Add("General Services, Department of");
            viewModel.Agency.Add("Governor&#39;s Office of Planning and Research");
            viewModel.Agency.Add("Governor, Office of the");
            viewModel.Agency.Add("Habeas Corpus Resource Center");
            viewModel.Agency.Add("Health and Human Services Agency");
            viewModel.Agency.Add("Health Benefit Exchange, California");
            viewModel.Agency.Add("Health Care Services, Department of");
            viewModel.Agency.Add("Health Information Integrity, California Office of");
            viewModel.Agency.Add("High-Speed Rail Authority");
            viewModel.Agency.Add("Highway Patrol, California");
            viewModel.Agency.Add("Horse Racing Board, California");
            viewModel.Agency.Add("Housing and Community Development, Department of");
            viewModel.Agency.Add("Housing Finance Agency");
            viewModel.Agency.Add("Human Resources, Department of");
            viewModel.Agency.Add("Independent Living Council, California State");
            viewModel.Agency.Add("Industrial Relations, Department of");
            viewModel.Agency.Add("Infrastructure and Economic Development Bank");
            viewModel.Agency.Add("Inspector General, Office of the");
            viewModel.Agency.Add("Insurance, Department of");
            viewModel.Agency.Add("Justice, Department of");
            viewModel.Agency.Add("Labor and Workforce Development Agency");
            viewModel.Agency.Add("Lands Commission, California State");
            viewModel.Agency.Add("Law Revision Committee");
            viewModel.Agency.Add("Legislative Analyst&#39;s Office");
            viewModel.Agency.Add("Legislative Counsel, Office of");
            viewModel.Agency.Add("Legislature, California State");
            viewModel.Agency.Add("Library, California State");
            viewModel.Agency.Add("Lieutenant Governor, Office of");
            viewModel.Agency.Add("Little Hoover Commission");
            viewModel.Agency.Add("Lottery, State");
            viewModel.Agency.Add("Managed Health Care, Department of");
            viewModel.Agency.Add("Managed Risk Medical Insurance Board");
            viewModel.Agency.Add("Medical Board of California");
            viewModel.Agency.Add("Mental Health Services Oversight and Accountability Commission");
            viewModel.Agency.Add("Military Department");
            viewModel.Agency.Add("Military Museum, California State");
            viewModel.Agency.Add("Motor Vehicles, Department of");
            viewModel.Agency.Add("Museum, the California");
            viewModel.Agency.Add("Natural Resources Agency");
            viewModel.Agency.Add("New Motor Vehicle Board");
            viewModel.Agency.Add("Parks and Recreation, Department of");
            viewModel.Agency.Add("Patient Advocate, Office of the");
            viewModel.Agency.Add("Peace Officer Standards and Training, Commission on");
            viewModel.Agency.Add("Personnel Board, State");
            viewModel.Agency.Add("Pesticide Regulation, Department of");
            viewModel.Agency.Add("Pilot Commissioners, Board of");
            viewModel.Agency.Add("Prison Industry Authority");
            viewModel.Agency.Add("Public Defender, Office of the State");
            viewModel.Agency.Add("Public Employees Retirement System, California");
            viewModel.Agency.Add("Public Employment Relations Board, California");
            viewModel.Agency.Add("Public Health, California Department of");
            viewModel.Agency.Add("Public Utilities Commission, California");
            viewModel.Agency.Add("Real Estate, Department of");
            viewModel.Agency.Add("Regenerative Medicine, California Institute for");
            viewModel.Agency.Add("Rehabilitation, Department of");
            viewModel.Agency.Add("Resources Recycling and Recovery, Department of");
            viewModel.Agency.Add("San Diego River Conservancy");
            viewModel.Agency.Add("San Francisco Bay Conservation and Development Commission");
            viewModel.Agency.Add("San Francisco Estuary Institute");
            viewModel.Agency.Add("San Gabriel and Lower Los Angeles Rivers and Mountains Conservancy");
            viewModel.Agency.Add("San Joaquin River Conservancy");
            viewModel.Agency.Add("Santa Monica Mountains Conservancy");
            viewModel.Agency.Add("Secretary of State");
            viewModel.Agency.Add("Seismic Safety Commission");
            viewModel.Agency.Add("Senate, California State");
            viewModel.Agency.Add("Sierra Nevada Conservancy");
            viewModel.Agency.Add("Small Business Development Centers");
            viewModel.Agency.Add("Social Services, Department of");
            viewModel.Agency.Add("State and Consumer Services Agency");
            viewModel.Agency.Add("State Hospitals, Department of");
            viewModel.Agency.Add("State Mandates, Commission on");
            viewModel.Agency.Add("Statewide Health Planning and Development,  Office of");
            viewModel.Agency.Add("Status of Women, Commission on");
            viewModel.Agency.Add("Student Aid Commission");
            viewModel.Agency.Add("Summer School for the Arts, California State");
            viewModel.Agency.Add("Systems Integration, Office of");
            viewModel.Agency.Add("Tahoe Conservancy, California");
            viewModel.Agency.Add("Teacher Credentialing, Commission on");
            viewModel.Agency.Add("Teachers&#39; Retirement System, California");
            viewModel.Agency.Add("Technology Agency, California");
            viewModel.Agency.Add("Toxic Substances Control, Department of");
            viewModel.Agency.Add("Traffic Safety, Office of");
            viewModel.Agency.Add("Transportation, Department of");
            viewModel.Agency.Add("Travel and Tourism Commission, California");
            viewModel.Agency.Add("Treasurer&#39;s Office, State");
            viewModel.Agency.Add("Unemployment Insurance Appeals Board");
            viewModel.Agency.Add("University of California");
            viewModel.Agency.Add("Veterans Affairs, Department of");
            viewModel.Agency.Add("Victim Compensation and Government Claims Board");
            viewModel.Agency.Add("Water Resources Control Board");
            viewModel.Agency.Add("Water Resources, Department of");
            viewModel.Agency.Add("Wildlife Conservation Board");
            return View("Apply", viewModel);
        }

        // GET: Apply
        [HttpPost]
        [Route("")]
        public ActionResult Index(ApplyModel viewModel)
        {
            return View("Apply");
        }
    }
}
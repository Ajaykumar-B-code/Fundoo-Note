﻿
using CommonLayer.RequestModels;
using CommonLayer.ResponseModel;
using ManagerLayer.Interface;
using ManagerLayer.Services;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace FundoNotes.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NotesController: ControllerBase
    {
        private INotesManager manager;

        public NotesController(INotesManager manager)
        {
            this.manager = manager;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]

        public ActionResult Creation(NotesCreatioinModel model)
        {
            int id = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = manager.NotesCeation(model,id);
            if (response != null)
            {
                return Ok(new ResModel<NotesEntity> { Success = true, Message = "created successfull", Data = response });
            }
            return BadRequest(new ResModel<NotesEntity> { Success = false,Message="creation failed",Data= response });
        }

        [Authorize]
        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            int id = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = manager.GetNotes(id);
            if (response != null)
            {
                return Ok(new ResModel<List<NotesEntity>> { Success = true, Message = "Notes displayed Sucessfully", Data = response });
            }
            return BadRequest(new ResModel<List<NotesEntity>> { Success = false, Message = "Notes displayed failed", Data = response });
        }

        [Authorize]
        [HttpPut]
        [Route("update")]
        public ActionResult update(NotesCreatioinModel model,int notesId)
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.UpdateNotes(id,model, notesId);
                if (response != null)
                {
                    return Ok(new ResModel<NotesEntity> { Success = true, Message = "Data updated Successfully", Data = response });
                }
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = "Data updation failed", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<NotesEntity> { Success=false,Message = ex.Message,Data=null});
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Trash")]
        public ActionResult isTrash(int notesId)
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.Istrash(id, notesId);
                if(response != null)
                {
                    return Ok(new ResModel<NotesEntity> { Success = true, Message = "added to Trash", Data = response });
                }
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = "failed to add in trash", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest( new ResModel<NotesEntity> { Success = false, Message = ex.Message, Data = null});
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int notesId)
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.Delete(id, notesId);
                if (response != null)
                {
                    return Ok(new ResModel<NotesEntity> { Success = true, Message = "deleted successfullt", Data = response });
                }
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = "failed to delete", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("addcolor")]
        public ActionResult AddColor(string colour,int notesId)
        {
            try
            {
                var response = manager.Addcolor(colour, notesId);
                if (response != null)
                {
                    return Ok(new ResModel<NotesEntity> { Success = true, Message = "colour added successfully", Data = response });
                }
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = "adding of colour failed", Data = response });
            }
            catch(Exception ex)
            {
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = ex.Message,Data = null});
            }
        }

        [Authorize]
        [HttpPut]
        [Route("archieve")]
        public ActionResult isArchieve(int notesId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.isArchieve(userId, notesId);
                if (response != null)
                {
                    return Ok(new ResModel<NotesEntity> { Success = true, Message = "notes Archieve successfully", Data = response });
                }
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = "notes Archieve failed", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("pin")]
        public ActionResult isPin(int notesId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.isPin(userId, notesId);
                if (response != null)
                {
                    return Ok(new ResModel<NotesEntity> { Success = true, Message = "notes Pinned", Data = response });
                }
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = "notes did not Pinned", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("AddRemainder")]
        public ActionResult AddRemainder(int notesId,DateTime time)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.AddRemander(notesId, time);
                if (response != null)
                {
                    return Ok(new ResModel<NotesEntity> { Success = true, Message = "Remainder Added", Data = response });
                }
                return BadRequest(new ResModel<NotesEntity> { Success = false, Message = "Remainder cannot be Added", Data = response });
            }
            catch(Exception ex)
            {
                return BadRequest( new ResModel<NotesEntity> { Success= false, Message = ex.Message,Data = null});
            }
        }

    }
}

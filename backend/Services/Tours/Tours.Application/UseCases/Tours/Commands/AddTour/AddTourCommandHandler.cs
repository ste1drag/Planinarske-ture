﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Repositories;
using Tours.Application.UseCases.Tours.Commands.DTOs;
using Tours.Domain.Entities;

namespace Tours.Application.UseCases.Tours.Commands.AddTour
{
    public class AddTourCommandHandler : IRequestHandler<AddTourCommand>
    {
        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;

        public AddTourCommandHandler(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        public async Task Handle(AddTourCommand request, CancellationToken cancellationToken)
        {
            Tour tour = _mapper.Map<Tour>(request.addTourDTO);
            await _toursRepository.Update(tour);
        }
    }
}
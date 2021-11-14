using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie4_2
{
    public class MuPlusLambda
    {
        private readonly Random _random = new Random();

        public MuPlusLambdaDto MuPlusLambdaAlgorithm(int mu, int parameterNumbers, int lambda, int tournamentSize,
            int mutationLevel, int iterations)
        {
            var muPool = CreateMuPool(mu, parameterNumbers);
            var lambdaPool = new List<IndividualDto>();
            for (var i = 0; i < iterations; i++)
            {
                lambdaPool = CreateLambdaPool(lambda, parameterNumbers, muPool, tournamentSize,
                    mutationLevel);
                var newMuPool = GetNewMuPool(muPool, lambdaPool, mu);
                muPool = newMuPool;
            }

            return new MuPlusLambdaDto
            {
                MuPool = muPool,
                LambdaPool = lambdaPool
            };
        }

        private List<IndividualDto> GetNewMuPool(List<IndividualDto> muPool, List<IndividualDto> lambdaPool, int mu)
        {
            var newMuPool = muPool.Concat(lambdaPool).OrderByDescending(x=>x.AdaptationFunctionValue).Take(mu).ToList();
            return newMuPool;
        }

        private List<IndividualDto> CreateMuPool(int mu, int parameterNumbers)
        {
            var individualList = new List<IndividualDto>();
            for (var i = 0; i < mu; i++)
                individualList.Add(CreateMuIndividual(parameterNumbers));

            return individualList;
        }

        private List<IndividualDto> CreateLambdaPool(int lambda, int parameterNumbers, List<IndividualDto> parentPool,
            int tournamentSize, int mutationLevel)
        {
            var individualList = new List<IndividualDto>();
            for (var i = 0; i < lambda; i++)
                individualList.Add(CreateLambdaIndividual(parentPool, tournamentSize, mutationLevel));

            return individualList;
        }

        private List<double> GetTournamentWinnerParameterList(List<IndividualDto> parentPool, int tournamentSize)
        {
            var tournamentParticipants = GetTournamentParticipants(parentPool, tournamentSize);
            var tournamentWinner = GetTournamentWinner(tournamentParticipants);
            var tournamentWinnerParemeterList = new List<double>();
            foreach(var parameter in tournamentWinner.ParametersList)
                tournamentWinnerParemeterList.Add(parameter);
            return tournamentWinnerParemeterList;
        }

        private IndividualDto GetTournamentWinner(List<IndividualDto> tournamentParticipants)
        {
            return tournamentParticipants.OrderByDescending(x => x.AdaptationFunctionValue).First();
        }

        private List<IndividualDto> GetTournamentParticipants(List<IndividualDto> parentPool, int tournamentSize)
        {
            var randomNumbersList = new List<int>();
            var tournamentParticipants = new List<IndividualDto>();
            while (tournamentParticipants.Count != tournamentSize)
            {
                var number = _random.Next(0, parentPool.Count);
                if (!randomNumbersList.Contains(number))
                {
                    randomNumbersList.Add(number);
                    tournamentParticipants.Add(parentPool[number]);
                }
            }

            return tournamentParticipants;
        }

        private IndividualDto CreateLambdaIndividual(List<IndividualDto> parentPool, int tournamentSize,
            int mutationLevel)
        {
            var tournamentWinnerParametersList = GetTournamentWinnerParameterList(parentPool, tournamentSize);
            for (var i = 0; i < tournamentWinnerParametersList.Count; i++)
                tournamentWinnerParametersList[i] += _random.NextDouble() * (mutationLevel - -mutationLevel) + -mutationLevel;
            var adaptationFunctionValue = GetAdaptationFunctionValue(tournamentWinnerParametersList);
            return new IndividualDto
            {
                ParametersList = tournamentWinnerParametersList,
                AdaptationFunctionValue = adaptationFunctionValue
            };
        }

        private IndividualDto CreateMuIndividual(int parameterNumbers)
        {
            var parameterList = CreateParameters(parameterNumbers);
            var adaptationFunctionValue = GetAdaptationFunctionValue(parameterList);
            return new IndividualDto
            {
                ParametersList = parameterList,
                AdaptationFunctionValue = adaptationFunctionValue
            };
        }

        private List<double> CreateParameters(int parameterNumbers)
        {
            var parameterList = new List<double>();

            for (var i = 0; i < parameterNumbers; i++)
                parameterList.Add(_random.NextDouble() * 100);

            return parameterList;
        }

        private double GetAdaptationFunctionValue(List<double> parameterList)
        {
            return
                Math.Sin(parameterList[0] * 0.05) + Math.Sin(parameterList[1] * 0.05) +
                0.4 * Math.Sin(parameterList[0] * 0.15) * Math.Sin(parameterList[1] * 0.15);
        }
    }
}